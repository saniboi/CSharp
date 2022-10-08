using System.Diagnostics.CodeAnalysis;

namespace _07_KonsolenEingabeUndAusgabe
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    EinZeichenLesen();
                    break;
                case 2:
                    EineZeileLesen();
                    break;
                case 3:
                    DreiArtenDerAusgabe();
                    break;
                case 4:
                    GanzerAblaufMitEinlesenKonvertierenValidierenUndSpeichern();
                    break;
                case 5:
                    ZeichenausgabeOhneZeilenumbruch();
                    break;
                case 6:
                    ZeichenausgabeMitZeilenumbruch();
                    break;
                case 7:
                    AusgabeFormatierenBeispiel1AlsHex();
                    break;
                case 8:
                    AusgabeFormatierenBeispiel2MitBreiteDerAusgabe();
                    break;
                case 9:
                    AusgabeFormatierenBeispiel3MitBreiteDerAusgabe();
                    break;
                case 10:
                    AusgabeFormatierenBeispiel4MitDimensionsangabe();
                    break;
                case 11:
                    AusgabeMitEscapeZeichen();
                    break;
            }
        }

        private static void EinZeichenLesen()
        {
            // Ein Zeichen lesen
            Console.WriteLine("Bitte geben Sie ein Zeichen ein und schliessen Sie mit Enter ab: ");
            char character = (char)Console.Read();  // Nur das erste Zeichen wird gelesen, auch wenn man mehrere eingibt; Abschluss mit Enter
                                                    // Read() gibt einen int zurück; darum braucht es die explizite Typumwandlung (casting) nach char
            Console.WriteLine($"Das Zeichen '{character}' hat den int-Wert {(int)character}.");
            // ASCII-Tabelle zum Gegenkontrollieren: https://en.wikipedia.org/wiki/ASCII#Printable_characters
        }

        private static void EineZeileLesen()
        {
            // Eine Zeile lesen
            Console.WriteLine("Bitte geben Sie eine Zeile ein und schliessen sie mit Enter ab: ");
            string input = Console.ReadLine()!;
            Console.WriteLine($"Input = {input}");
        }

        private static void DreiArtenDerAusgabe()
        {
            int einInteger = 10;
            Console.WriteLine("Die eingegebene Zahl war: " + einInteger);                    // Erste Generation: Mit Plus "+"
            Console.WriteLine("Die eingegebene Zahl war: {0} und {0:C}", einInteger);        // Zweite Generation: Mit string.Format(...)
            Console.WriteLine($"Die eingegebene Zahl war: {einInteger} und {einInteger:C}"); // Dritte Generation: Mit String-Interpolation ab C# 6 (2015) ← Empfohlen Variante
                                                                                             // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
        }

        private static void GanzerAblaufMitEinlesenKonvertierenValidierenUndSpeichern()
        {
            // Ganzer Ablauf: einlesen, konvertieren, validieren, speichern

            // Eingabenaufforderung
            Console.WriteLine("Geben Sie eine Zahl ein: ");

            // Einlesen
            string input = Console.ReadLine()!;

            // Konvertierung und Validierung in einem

            // Alt:
            //int einInteger;
            //bool konvertierungWarErfolgreich = Int32.TryParse(input, out einInteger)

            // Neu ab C# 7.0 (2017): inline out Variablen
            // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#out-variables
            bool konvertierungWarErfolgreich = Int32.TryParse(input, out int einInteger);
            if (konvertierungWarErfolgreich)
            {
                // Speicherung bzw. Ausgabe
                Console.WriteLine($"Die eingegebene Zahl war: {einInteger}");
            }
            else
            {
                // Speicherung bzw. Ausgabe
                Console.WriteLine("Sie haben keine Zahl eingegeben.");
            }
        }

        private static void ZeichenausgabeOhneZeilenumbruch()
        {
            // Zeichenausgabe ohne Zeilenumbruch
            Console.Write("Hallo,");
            Console.Write(" ");
            Console.Write("World!");
        }

        private static void ZeichenausgabeMitZeilenumbruch()
        {
            // Zeichenausgabe mit Zeilenumbruch
            Console.WriteLine("Hallo,");
            Console.WriteLine("World 1!");

            // Alternative alt mit \n
            Console.Write("Hallo,\n");
            Console.Write("World 2!\n");

            // Alternative neu mit Environment.NewLine
            Console.Write($"Hallo,{Environment.NewLine}"); // NewLine ist plattformunabhängig. Siehe Eigenschaftenkommentar mit Maus-Hover.
            Console.Write($"World 3!{Environment.NewLine}");
        }

        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        private static void AusgabeFormatierenBeispiel1AlsHex()
        {
            int einHex;
            einHex = 0xFF; // Dezimal 255 zuweisen
            Console.WriteLine($"Zahl = {einHex}");   // int wird im Dezimalsystemausgegeben, schliesslich ist es ja ein int
            Console.WriteLine($"Zahl = {einHex:X}"); // Mit dem "X"-Argument wird die int-Zahl im Hexadezimalsystem dargestellt
        }

        private static void AusgabeFormatierenBeispiel2MitBreiteDerAusgabe()
        {
            int zeit = 5;

            string text = $"Es ist {zeit,2} Uhr.";
            Console.WriteLine(text);

            Console.WriteLine($"Es ist {zeit,2} Uhr."); // WriteLine() verwendet intern auch string.Format()
        }

        [SuppressMessage("ReSharper", "PossiblyMistakenUseOfInterpolatedStringInsert")]
        private static void AusgabeFormatierenBeispiel3MitBreiteDerAusgabe()
        {
            // Ausgabe formatieren
            // Syntax {N [,M][:Format]}
            //  N:          Parameterindex beginnend mit 0
            //  ,M:         Breite der Ausgabe (optional)
            //  :Format:    Optionale Formatangabe (optional)
            // Dokumentation: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
            int zeit1 = 5;
            int zeit2 = 12;
            Console.WriteLine($"Es ist {zeit1,2} Uhr.");
            Console.WriteLine($"Es ist {zeit2,2} Uhr.");

            Console.WriteLine($"Zahl: {1,10}.");
            Console.WriteLine($"Zahl: {10,10}.");
            Console.WriteLine($"Zahl: {100,10}.");
            Console.WriteLine($"Zahl: {1000,10}.");
        }

        private static void AusgabeFormatierenBeispiel4MitDimensionsangabe()
        {
            int x = 1234;
            Console.WriteLine($"Zahl = {x:D}");       // Ausgabe: Zahl = 1234; Exception, wenn x kein int ist
            Console.WriteLine($"Zahl = {x:D10}");     // Ausgabe: Zahl = 0000001234; Exception, wenn x kein int ist

            double zahl = 1203.5;
            Console.WriteLine($"Zahl = {zahl:C}");    // Ausgabe: Zahl = CHF 1'203.50
            Console.WriteLine($"Zahl = {zahl:E}");    // Ausgabe: Zahl = 1.203500E+003
            Console.WriteLine($"Zahl = {zahl:E2}");   // Ausgabe: Zahl = 1.20E+003
            Console.WriteLine($"Zahl = {zahl:E3}");   // Ausgabe: Zahl = 1.204E+003; wird gerundet
            Console.WriteLine($"Zahl = {zahl:F2}");   // Ausgabe: Zahl = 1203.50
            Console.WriteLine($"Zahl = {zahl:P2}");   // Ausgabe: Zahl = 120'350.00%

            int iHex = 254;
            Console.WriteLine($"Zahl = {iHex:X}");    // Ausgabe: Zahl = FE; das "X" kennen wir schon von ToString("X")

            // Dokumentation: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
        }

        private static void AusgabeMitEscapeZeichen()
        {
            // Escape-Zeichen

            Console.WriteLine("\a");       // Beep-Ton

            //Console.WriteLine("\");      // Geht nicht, weil es als Escape-Zeichen verwendet wird und diese Bedeutung hat, wenn es einzeln auftaucht
            Console.WriteLine("\\");       // Das geht
            char c = '\'';                 // Ein Hochkomma innerhalb eines chars muss auch mit \ markiert werden
            Console.WriteLine(c);

            Console.WriteLine("---");
            Console.Write("\n\n\n");       // Write ohne "Line", aber mit \n
            Console.WriteLine("---");

            Console.WriteLine("a\t\t\tb");

            Console.WriteLine("മലയാളം"); // മലയാളം = Malayalam
            Console.WriteLine("\u0d2e\u0d32\u0d2f\u0d3e\u0d33\u0d02"); // മലയാളം = Malayalam
                                                                       // cmd-Konsole kann keine Unicode-Zeichen darstellen, d.h. man sieht daher nur "??????"
                                                                       // Powershell kann Unicode-Zeichen darstellen, aber man muss es zuerst einschalten mit
                                                                       //    $OutputEncoding = [console]::InputEncoding = [console]::OutputEncoding = New-Object System.Text.UTF8Encoding
                                                                       // und dann direkt KonsolenEingabeUndAusgabe.exe laufen lassen
                                                                       // Quelle: https://stackoverflow.com/questions/49476326/displaying-unicode-in-powershell
        }
    }
}
