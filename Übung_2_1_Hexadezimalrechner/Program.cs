using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

// ReSharper disable CheckNamespace
namespace Übung_2_1_Hexadezimalrechner
{
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    public class Program
    {
        static void Main()
        {
            V0_1_Hartkodierte_Werte_und_nur_dezimal();
            //V0_2_Hartkodierte_Werte_zusätzlich_mit_Hexadezimalausgabe();
            //V0_3_Hartkodierte_Werte_zusätzlich_mit_Hexadezimalausgabe();
            //V0_4_Mit_Benutzereingabe();
            //V0_5_Refactoring();
            //V1_0_Mit_Benutzereingabevalidierung_und_Schlaufe_und_Division_durch_Null();
            //V2_0_Mit_sprechendem_Code_mit_Methoden();
            //V3_0_Objekt_orientierte_Version();
        }

        /// <summary>
        /// Hier probieren wir eine absolut minimale Version zum Laufen zu kriegen:
        /// - Werte hartkodieren (keine Benutzereingabe)
        /// - Nur Addition (Komplexität reduzieren, indem wir nicht gleichzeitig noch Subtraktion, Multiplikation und Division implementieren)
        /// - Nur Dezimalausgabe (noch keine Hexadezimalausgabe)
        /// </summary>
        private static void V0_1_Hartkodierte_Werte_und_nur_dezimal()
        {
            int a = 1;
            int b = 2;
            int summe = a + b;
            Console.WriteLine("a + b = Summe");
            Console.WriteLine($"{a} + {b} = {summe}");
        }

        /// <summary>
        /// Nächste Funktionalität: Bei der Ausgabe die Dezimalzahl als Hexadezimalzahl ausgeben
        /// </summary>
        private static void V0_2_Hartkodierte_Werte_zusätzlich_mit_Hexadezimalausgabe()
        {
            int a = 1;
            int b = 2;
            int summe = a + b;
            Console.WriteLine("a + b = Summe");
            Console.WriteLine($"Dezimalausgabe: {a} + {b} = {summe}");
            Console.WriteLine($"Hexadezimalausgabe: {a:X} + {b:X} = {summe:X}");
        }

        /// <summary>
        /// Nächste Version: Andere Zahlen wählen, damit man einen Unterschied zwischen Dezimal- und Hexadezimalausgabe erkennen kann
        /// </summary>
        private static void V0_3_Hartkodierte_Werte_zusätzlich_mit_Hexadezimalausgabe()
        {
            int a = 10;
            int b = 11;
            int summe = a + b;
            Console.WriteLine("a + b = Summe");
            Console.WriteLine($"Dezimalaussgabe: {a} + {b} = {summe}");
            Console.WriteLine($"Hexadezimalausgabe: {a:X} + {b:X} = {summe:X}");
        }

        /// <summary>
        /// Nächste Funktionalität: Mit Benutzereingabe
        /// - Aber noch ohne Validierung; Programm stürzt bei invalider Benutzereingabe ab, z.B. wenn man "X" eingibt
        /// - Alle Operationen hartkodiert
        /// </summary>
        private static void V0_4_Mit_Benutzereingabe()
        {
            Console.Write("Erste Hexzahl eingeben: ");
            string inputString = Console.ReadLine();
            var zahl1 = int.Parse(inputString, NumberStyles.HexNumber);

            Console.Write("Zweite Hexzahl eingeben: ");
            inputString = Console.ReadLine();
            var zahl2 = int.Parse(inputString, NumberStyles.HexNumber);

            Console.WriteLine($"Summe in Hex = {zahl1 + zahl2:X}");
            Console.WriteLine($"Differenz in Hex = {zahl1 - zahl2:X}");
            Console.WriteLine($"Produkt in Hex = {zahl1 * zahl2:X}");
            Console.WriteLine($"Quotient in Hex = {zahl1 / zahl2:X}");
        }

        /// <summary>
        /// Eine schöner strukturierte Version:
        /// - Sprechendere Variablennamen
        /// - Klarere Konsolenausgabe
        ///
        /// Refactoring: Struktur des Codes ändern, ohne das Verhalten zu ändern
        /// </summary>
        private static void V0_5_Refactoring()
        {
            // Erste Zahl einlesen
            Console.Write("Erste Hexadezimalzahl eingeben: ");
            var benutzereingabe = Console.ReadLine();
            var zahl1 = int.Parse(benutzereingabe, NumberStyles.HexNumber);

            // Zweite Zahl einlesen
            Console.Write("Zweite Hexadezimalzahl eingeben: ");
            benutzereingabe = Console.ReadLine();
            var zahl2 = int.Parse(benutzereingabe, NumberStyles.HexNumber);

            // Rechenoperationen durchführen (ohne Benutzerauswahl)
            int summe = zahl1 + zahl2;
            int differenz = zahl1 - zahl2;
            int produkt = zahl1 * zahl2;
            int quotient = zahl1 / zahl2;

            // Ergebnisse Ausgeben
            Console.WriteLine();
            Console.WriteLine($"Zahl 1:    {zahl1:X} ({zahl1})");
            Console.WriteLine($"Zahl 2:    {zahl2:X} ({zahl2})");
            Console.WriteLine();
            Console.WriteLine($"Summe:     {summe:X} ({summe})");
            Console.WriteLine($"Differenz: {differenz:X} ({differenz})");
            Console.WriteLine($"Produkt:   {produkt:X} ({produkt})");
            Console.WriteLine($"Quotient:  {quotient:X} ({quotient})");
            Console.WriteLine();
        }

        /// <summary>
        /// Eine Version mit Eingabevalidierung.
        /// </summary>
        private static void V1_0_Mit_Benutzereingabevalidierung_und_Schlaufe_und_Division_durch_Null()
        {
            bool benutzereingabeIstGültig;

            // Erste Zahl einlesen
            int ersteZahlAlsDez;
            string ersteZahlAlsHex;
            do
            {
                Console.Write("Erste Hexadezimalzahl eingeben: ");
                ersteZahlAlsHex = Console.ReadLine();
                // https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=netframework-4.8#System_Int32_TryParse_System_String_System_Globalization_NumberStyles_System_IFormatProvider_System_Int32__
                benutzereingabeIstGültig = int.TryParse(ersteZahlAlsHex, NumberStyles.HexNumber, null, out ersteZahlAlsDez);

            } while (!benutzereingabeIstGültig); // Das "!" steht für "not" und haben wir noch nicht gelernt
            Console.WriteLine($"Zahl 1 = {ersteZahlAlsHex} ({ersteZahlAlsDez})");

            // Zweite Zahl einlesen
            int zweiteZahlAlsDez;
            string zweiteZahlAlsHex;
            do
            {
                Console.Write("Zweite Hexadezimalzahl eingeben: ");
                zweiteZahlAlsHex = Console.ReadLine();
                benutzereingabeIstGültig = int.TryParse(zweiteZahlAlsHex, NumberStyles.HexNumber, null, out zweiteZahlAlsDez);

            } while (!benutzereingabeIstGültig); // Das "!" steht für "not" und habe wir noch nicht gelernt
            Console.WriteLine($"Zahl 2: {zweiteZahlAlsHex} ({zweiteZahlAlsDez})");

            // Rechenoperationen durchführen (ohne Benutzerauswahl)
            int summe = ersteZahlAlsDez + zweiteZahlAlsDez;
            int differenz = ersteZahlAlsDez - zweiteZahlAlsDez;
            int produkt = ersteZahlAlsDez * zweiteZahlAlsDez;
            int quotient = 0;
            try
            {
                // Division durch 0 abfangen
                quotient = ersteZahlAlsDez / zweiteZahlAlsDez;
            }
            catch (Exception e)
            {
                // Todo: Der Division-durch-Null-Fall muss noch abgehandelt werden
                Console.WriteLine(e);
            }

            // Ergebnisse Ausgeben
            Console.WriteLine();
            Console.WriteLine($"Zahl 1:    {ersteZahlAlsDez:X} ({ersteZahlAlsDez})");
            Console.WriteLine($"Zahl 2:    {zweiteZahlAlsDez:X} ({zweiteZahlAlsDez})");
            Console.WriteLine();
            Console.WriteLine($"Summe:     {summe:X} ({summe})");
            Console.WriteLine($"Differenz: {differenz:X} ({differenz})");
            Console.WriteLine($"Produkt:   {produkt:X} ({produkt})");
            Console.WriteLine($"Quotient:  {quotient:X} ({quotient})");
            Console.WriteLine();
        }

        #region V2_0_Mit_sprechendem_Code_mit_Methoden()

        /// <summary>
        /// Gleich wie die letzte Version mit Eingabevalidierung, aber mit Methoden (haben wir noch nicht offiziell kennengelert), um besser lesbaren
        /// Code zu erhalten.
        /// </summary>
        private static void V2_0_Mit_sprechendem_Code_mit_Methoden()
        {
            bool benutzerWillWeitereRechnungenDurchführen;

            do
            {
                int ersterWert = ErstenWertEinlesen();
                string operand = OperandenEinlesen();
                int zweiterWert = ZweitenWertEinlesen();
                double ergebnis = BerechnungAusführen(ersterWert, operand, zweiterWert);
                ErgebnisAusgeben(ersterWert, operand, zweiterWert, ergebnis);
                benutzerWillWeitereRechnungenDurchführen = BenutzerFragenObErWeiterrechnenWill();
            } while (benutzerWillWeitereRechnungenDurchführen);
        }

        private static int ErstenWertEinlesen()
        {
            bool benutzereingabeIstGültig;
            int ersteZahlAlsDez;

            do
            {
                Console.Write("Erste Hexadezimalzahl eingeben: ");
                var ersteZahlAlsHex = Console.ReadLine();
                // https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=netframework-4.8#System_Int32_TryParse_System_String_System_Globalization_NumberStyles_System_IFormatProvider_System_Int32__
                benutzereingabeIstGültig = int.TryParse(ersteZahlAlsHex, NumberStyles.HexNumber, null, out ersteZahlAlsDez);

            } while (!benutzereingabeIstGültig); // Das "!" steht für "not" und haben wir noch nicht gelernt

            return ersteZahlAlsDez;
        }

        private static string OperandenEinlesen()
        {
            bool benutzereingabeIstGültig;
            string[] gültigeOperatoren = { "+", "-", "*", "/" };
            string operand;

            do
            {
                Console.Write("Operation eingeben (+, -, *, /): ");
                operand = Console.ReadLine();
                benutzereingabeIstGültig = gültigeOperatoren.Contains(operand);
            } while (!benutzereingabeIstGültig); // Das "!" steht für "not" und haben wir noch nicht gelernt

            return operand;
        }


        // Todo: ZweitenWertEinlesen() ist fast identisch programmiert wie ErstenWertEinlesen() → Hier sollte man noch die Codeduplikation entfernen

        private static int ZweitenWertEinlesen()
        {
            bool benutzereingabeIstGültig;
            int zweiteZahlAlsDez;

            do
            {
                Console.Write("Zweite Hexadezimalzahl eingeben: ");
                var zweiteZahlAlsHex = Console.ReadLine();
                benutzereingabeIstGültig = int.TryParse(zweiteZahlAlsHex, NumberStyles.HexNumber, null, out zweiteZahlAlsDez);

            } while (!benutzereingabeIstGültig); // Das "!" steht für "not" und habe wir noch nicht gelernt

            Console.WriteLine();
            return zweiteZahlAlsDez;
        }

        private static double BerechnungAusführen(int ersteZahlAlsDez, string operand, int zweiteZahlAlsDez)
        {
            double ergebnis = 0;

            switch (operand)
            {
                case "+":
                    int summe = ersteZahlAlsDez + zweiteZahlAlsDez;
                    ergebnis = summe;
                    break;
                case "-":
                    int differenz = ersteZahlAlsDez - zweiteZahlAlsDez;
                    ergebnis = differenz;
                    break;
                case "*":
                    int produkt = ersteZahlAlsDez * zweiteZahlAlsDez;
                    ergebnis = produkt;
                    break;
                case "/":
                    try // Division-durch-Null-Fall beachten
                    {
                        int quotient = ersteZahlAlsDez / zweiteZahlAlsDez;
                        ergebnis = quotient;
                    }
                    catch (Exception e)
                    {
                        // Todo: Der Division-durch-Null-Fall muss noch abgehandelt werden
                        Console.WriteLine(e);
                    }
                    break;
            }

            return ergebnis;
        }

        private static void ErgebnisAusgeben(int ersteZahlAlsDez, string operand, int zweiteZahlAlsDez, double ergebnis)
        {
            Console.WriteLine($"Zahl 1:    {ersteZahlAlsDez:X} ({ersteZahlAlsDez})");
            Console.WriteLine($"Operand:   {operand}");
            Console.WriteLine($"Zahl 2:    {zweiteZahlAlsDez:X} ({zweiteZahlAlsDez})");
            switch (operand)
            {
                case "+":
                    int summe = (int)ergebnis;
                    Console.WriteLine($"Summe:     {summe:X} ({summe})");
                    break;
                case "-":
                    int differenz = (int)ergebnis;
                    Console.WriteLine($"Differenz: {differenz:X} ({differenz})");
                    break;
                case "*":
                    int produkt = (int)ergebnis;
                    Console.WriteLine($"Produkt:   {produkt:X} ({produkt})");
                    break;
                case "/":
                    int quotient = (int)ergebnis;
                    Console.WriteLine($"Quotient:  {quotient:X} ({quotient})");
                    break;
            }
        }

        private static bool BenutzerFragenObErWeiterrechnenWill()
        {
            bool antwortDesBenutzersIstDassErWeiterrechnenWill;

            string antwortAlsString = GültigeAntwortVomBenutzerEinlesen();
            switch (antwortAlsString)
            {
                case "y":
                    antwortDesBenutzersIstDassErWeiterrechnenWill = true;
                    break;
                default:
                    antwortDesBenutzersIstDassErWeiterrechnenWill = false;
                    break;
            }

            return antwortDesBenutzersIstDassErWeiterrechnenWill;
        }

        private static string GültigeAntwortVomBenutzerEinlesen()
        {
            string antwortAlsString = string.Empty;
            bool benutzerEingabeIstGültig = false;

            do
            {
                Console.WriteLine("Möchten Sie eine weitere Rechenoperation ausführen? (y/n): ");
                string antwort = Console.ReadLine();
                antwort = antwort?.ToLower();
                string[] gültigeAntworten = { "y", "n" };
                if (gültigeAntworten.Contains(antwort))
                {
                    benutzerEingabeIstGültig = true; // Abbruchkriterium
                    antwortAlsString = antwort;
                }
            } while (!benutzerEingabeIstGültig);

            return antwortAlsString;
        }

        #endregion


        #region V3_0_Objekt_orientierte_Version

        /// <summary>
        /// Objektorientiert, aber noch ohne Benutzereingabe
        ///
        /// Beachte: Wir haben Verantwortlichkeiten in unterschiedliche Klassen getrennt.
        /// Klasse Taschenrechner übernimmt alles, was mit der Berechnungslogik zu tun hat.
        /// Klasse AusgabeFürTaschenrechner übernimmt alles, was mit der Darstellung auf dem UI (hier die Konsole) zu tun hat.
        ///
        /// Beispiel, wo dadurch die Wartung/Weiterentwicklung vereinfacht:
        /// - Wenn wir die Anzeige im Browser darstellen wollen, müssen wir nur die Klasse AusgabeFürTaschenrechner ersetzen
        /// - Wenn wir die Berechnungslogik auf iOS verwenden wollen, können wir die Klasse Taschenrechner wiederverwenden, weil
        ///   sie keine Abhängigkeiten zur Windows-Konsole hat.
        /// </summary>
        private static void V3_0_Objekt_orientierte_Version()
        {
            // Objekt instanziieren
            var taschenrechner = new Taschenrechner
            {
                ErsterWert = 0xF,
                ZweiterWerte = 0xF,
                Operation = Operation.Addition
            };

            // Berechnung ausführen
            taschenrechner.RechnungAusführen();

            // Ergebnis ausgeben
            var ergebnisAnzeige = new AusgabeFürTaschenrechner();
            ergebnisAnzeige.AnzeigeErstellen(taschenrechner);
        }

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public enum Operation
        {
            Addition,
            Subtraktion,
            Division,
            Multiplikation
        }

        public class Taschenrechner
        {
            public int ErsterWert { get; set; }
            public int ZweiterWerte { get; set; }
            public Operation Operation { get; set; }
            public int Ergebnis { get; set; }

            public void RechnungAusführen()
            {
                switch (Operation)
                {
                    case Operation.Addition:
                        Ergebnis = ErsterWert + ZweiterWerte;
                        break;
                    default:
                        throw new NotImplementedException("Diese Operation ist noch nicht implementiert");
                }
            }
        }

        class AusgabeFürTaschenrechner
        {
            public void AnzeigeErstellen(Taschenrechner taschenrechner)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("                                 Dezimalzahl             Hexadezimalzahl   ");
                Console.WriteLine($"Erste Zahl:     {taschenrechner.ErsterWert,25} {taschenrechner.ErsterWert,20:X}");
                Console.WriteLine($"Operand:        {taschenrechner.Operation}");
                Console.WriteLine($"Zweite Zahl:    {taschenrechner.ZweiterWerte,25} {taschenrechner.ZweiterWerte,20:X}");
                Console.WriteLine($"Ergebnis:       {taschenrechner.Ergebnis,25} {taschenrechner.Ergebnis,20:X}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        #endregion
    }
}