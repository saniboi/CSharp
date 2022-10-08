using System.Diagnostics.CodeAnalysis;

namespace _02_Datentypen
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
                    VarianblennamenRegeln();
                    Begriffe();
                    break;
                case 2:
                    KompilerWarnungenUndImpliziteDatentypkonvertierung();
                    break;
                case 3:
                    AliasStattDatentypnamenVerwenden();
                    break;
                case 4:
                    Fliesskommazahlen();
                    break;
                case 5:
                    Suffixe();
                    break;
                case 6:
                    Hexadezimalzahlen();
                    break;
                case 7:
                    ImplizitTypisierteLokaleVariablenMitSchlüsselwortVar();
                    break;
                case 8:
                    MehrfacheVariablendeklarationIstUngültig();
                    break;
                case 9:
                    Referenztypen();
                    break;
                case 10:
                    WertetypenUndReferenztypen();
                    break;
                case 11:
                    ImpliziteDatentypkonvertierung();
                    break;
                case 12:
                    ExpliziteDatentypkonvertierung();
                    break;
                case 13:
                    DatentypkonvertierungInStringMitToString();
                    break;
                case 14:
                    DatentypkonvertierungVonStringNachInt();
                    break;
                case 15:
                    DatentypkonvertierungMitTryParse();
                    break;
                case 16:
                    DatentypkonvertierungMitKlasseConvert();
                    break;
                case 17:
                    SchlüsselwortTypeofUndMethodeGetType();
                    break;
            }
        }

        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static void VarianblennamenRegeln()
        {
            // Variablennamen müssen bestimmten Regeln gehorchen
            int a;
            int b = 20, c = 50;
            double _x, y_1, z1;

            // Auch ein Unterstrich ist ein gültiger Variablenname, aber es ist eine schlechte Wahl,
            // weil wir sprechende Bezeichner wählen wollen.
            int _ = 1;
            Console.WriteLine(_);



            // Ein paar Console.WriteLine-Ausgaben, damit Visual Studio die Warnung "The variable 'a' is declared but never used" nicht mehr anzeigt
            a = 1;
            _x = 1;
            y_1 = 1;
            z1 = 1;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(_x);
            Console.WriteLine(y_1);
            Console.WriteLine(z1);
        }

        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static void Begriffe()
        {
            // Begriffe
            int x;      // Deklaration
            x = 1;      // Initialisierung (das erste Mal)
            x = 2;      // Wertzuweisung
            int y = 3;  // Deklaration und Initialisierung in einer Zeile

            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = {y}");
        }

        private static void KompilerWarnungenUndImpliziteDatentypkonvertierung()
        {
            // Compiler verhindert, dass man invalide Werte z.B. in einen byte schreibt
            //byte b = -1; // Das geht nicht, weil -1 negativ ist

            byte b1 = 255;
            byte b2 = 1;
            //byte b3 = b1 + b2; // Q: Warum ist die Summe zweier byte ein int?
            // Error CS0266  Cannot implicitly convert type 'int' to 'byte'. An explicit conversion exists (are you missing a cast?)

            // A: Es ist keine "+"-Operation für byte definiert, darum werden beide bytes zuerst in int konvertiert und
            // die "+"-Operation für int ausgeführt → Darum ist das Ergebnis ein int und kein byte
            //
            // Quelle:
            // https://stackoverflow.com/questions/941584/byte-byte-int-why#comment6287210_941665
            // https://stackoverflow.com/a/941627

            // Die Antwort auf die Frage "Was (nicht warum) ist die Summe zweier byte ein int?" selber herausfinden:
            byte b4 = (byte)(b1 + b2);
            Console.WriteLine((b1 + b2).GetType()); // Hier kann die Methode GetType() helfen, dem Problem auf die Schliche zu kommen
            Console.WriteLine($"b4 = {b4}");

            int i = b1 + b2;
            Console.WriteLine($"i = {i}");
        }

        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        [SuppressMessage("ReSharper", "RedundantNameQualifier")]
        private static void AliasStattDatentypnamenVerwenden()
        {
            // Konvention: Immer den Alias, z.B. string, verwenden und nicht den .NET-Typnamen, z.B. System.String
            string s1;
            System.String s2;


            // Ein paar Console.WriteLine-Ausgaben, damit Visual Studio die Warnung "The variable 'a' is declared but never used" nicht mehr anzeigt
            s1 = string.Empty;
            s2 = string.Empty;
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }

        private static void Fliesskommazahlen()
        {
            // Fliesskommazahlen
            float f = 23.0f; // Das f nach 23.0 ist zwingend, weil 23.0 sonst als double interpretiert wird
                             // und eine Konvertierung von double nach float nicht ohne Präzisionsverlust
                             // durchgeführt werden kann
                             //
                             // Alle Fliesskommazahlen werde als double und alle Ganzzahlen als int (Int32) interpretiert,
                             // wenn keine Suffixe angegeben werden



            // Ein paar Console.WriteLine-Ausgaben, damit Visual Studio die Warnung "The variable 'a' is declared but never used" nicht mehr anzeigt
            Console.WriteLine(f);
        }

        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        private static void Suffixe()
        {
            float z1;
            double z2;
            decimal z3;
            z1 = 3.21F;
            //z2 = 6543.23421D; // Mit "D"-Suffix; ist aber nicht nötig, weil Standardmässig Double angenommen wird, wenn nichts steht → siehe nächste Zeile
            z2 = 423.12312;
            z3 = 4223452.2345454323M;  // Empfehlung: Datentyp "decimal" verwenden, wenn man mit Währungen arbeitet, sonst kriegt man zu grosse Rundungsfehler

            char c = 'a'; // Mit einfachen Anführungszeichen (single quotes)


            // Ein paar Console.WriteLine-Ausgaben, damit Visual Studio die Warnung "The variable 'a' is declared but never used" nicht mehr anzeigt
            Console.WriteLine(z1);
            Console.WriteLine(z2);
            Console.WriteLine(z3);
            Console.WriteLine(c);
        }

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        private static void Hexadezimalzahlen()
        {
            // Hexadezimalzahlen: https://www.tabelle.info/hexadezimalzahlen.html
            int aHex;
            aHex = 0xFF; // Dezimal 255 zuweisen
            Console.WriteLine($"aHex: {aHex}");

            // Den int 255 als Hex darstellen und dazu in eine Zeichnekette (string) umwandeln
            string hexValue = aHex.ToString("X");
            Console.WriteLine($"hexValue: {hexValue}");

            // Hex (string) in ein int umwandeln
            int decAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine($"decAgain: {decAgain}");

            // Hex (string) in ein int umwandeln, dieses Mal aber aus der Konsoleneingabe
            Console.Write("Hex-Wert eingeben: ");
            string benutzereingabe = Console.ReadLine();
            decAgain = int.Parse(benutzereingabe, System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine($"decAgain: {decAgain}");

            // Quelle: http://stackoverflow.com/a/1139975
        }

        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        private static void ImplizitTypisierteLokaleVariablenMitSchlüsselwortVar()
        {
            // Implizit typisierte lokale Variablen: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
            // Das Schlüsselwort "var" is seit C# 3.0 (2007) verfügbar

            // Explizit und implizit
            int i1 = 1; // Explizit typisiert
            var i2 = 1; // Implizit typisiert
            int[] array1 = new int[] { 1, 2 }; // Explizit typisiert
            var array2 = new int[] { 1, 2 }; // Implizit typisiert

            // Fall 1: var kann nicht verwendet werden, wenn der Typ unbekannt ist
            //var j;    // Geht nicht, da der Typ zum Deklarationszeitpunkt nicht bekannt ist
            //j = 2;

            // Fall 2: var kann verwendet werden, wenn der Typ bekannt ist
            var k = 1;

            // Fall 3: var muss verwendet werden bei anonymen Typen
            var m = new { Farbe = "rot" }; // Anonmymer Typ

            // Für Fortgeschrittene
            //var x = null; // Geht nicht, da der Typ nicht ableitbar ist
            var x = (string)null; // Wenn man null aber in einen Typ konvertiert, geht es wiederum,
                                  // weil dann der Typ ableitbar ist


            // Ein paar Console.WriteLine-Ausgaben, damit Visual Studio die Warnung "The variable 'a' is declared but never used" nicht mehr anzeigt
            Console.WriteLine($"i1: {i1}");
            Console.WriteLine($"i2: {i2}");
            Console.WriteLine($"k: {k}");
            Console.WriteLine($"m: {m}");
            Console.WriteLine($"array1: {array1}");
            Console.WriteLine($"x: {x}");
        }

        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        private static void MehrfacheVariablendeklarationIstUngültig()
        {
            int i;
            //int i; // Mehrfache Definition von Variabeln mit demselben Namen ist nicht zulässig



            // Ein paar Console.WriteLine-Ausgaben, damit Visual Studio die Warnung "The variable 'a' is declared but never used" nicht mehr anzeigt
            i = 1;
            Console.WriteLine($"i: {i}");
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void Referenztypen()
        {
            Person person1 = new Person();  // Ab C# 1: "Person" zweimal schreiben
            var person2 = new Person();     // Ab C# 3: var-Schlüsselwort wird eingeführt
            Person person3 = new();         // Ab C# 9: Target typed new expression wird eingeführt https://channel9.msdn.com/Shows/On-NET/C-Language-Highlights-Target-Typed-new-expressions
        }

        private static void WertetypenUndReferenztypen()
        {
            // Unterschied im Verhalten zwischen Wertetypen und Referenztypen bei Zuweisungen

            // Wertetypen
            int a = 1;
            int b = 2;
            Console.WriteLine("Vor der Zuweisung");
            Console.WriteLine($"  a = {a}");
            Console.WriteLine($"  b = {b}");

            a = b;
            Console.WriteLine("Nach der Zuweisung");
            Console.WriteLine($"  a = {a}");
            Console.WriteLine($"  b = {b}");

            // b wieder verändern, aber a beleibt umverändert, weil Wertetypen ihren eigenen Speicherbereich haben
            b = 3;
            Console.WriteLine("Nach Veränderung von b, bleibt a unverändert");
            Console.WriteLine($"  a = {a}");
            Console.WriteLine($"  b = {b}");
            Console.WriteLine();


            // Referenztypen (verhalten sich anders als Wertetypen)

            Console.WriteLine("Vor der Zuweisung");
            Person hans = new Person { Firstname = "Hans", Lastname = "Müller" };
            Person sara = new Person { Firstname = "Sara", Lastname = "Meier" };
            Console.WriteLine($"  Hans: {hans}");
            Console.WriteLine($"  Sara: {sara}");

            hans = sara;
            Console.WriteLine("Nach der Zuweisung");
            Console.WriteLine($"  Hans: {hans}");
            Console.WriteLine($"  Sara: {sara}");

            // sara wieder verändern, und diese Mal ändert hans mit, weil mehrer Referenzen auf den gleichen Speicherbereich zeigen/referenzieren können
            sara.Firstname = "Petra";
            Console.WriteLine("Nach Veränderung von sara.Firstname ändert auch hans.Firstname");
            Console.WriteLine($"  Hans: {hans}");
            Console.WriteLine($"  Sara: {sara}");
        }

        public class Person
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }

            public override string ToString()
            {
                return $"{Firstname} {Lastname}";
            }
        }

        private static void ImpliziteDatentypkonvertierung()
        {
            // Implizite Datentypkonvertierung
            byte b = 255;
            int i = b;
            double d = i;
            Console.WriteLine($"d = {d}");

            Type t = 255.GetType();
            Console.WriteLine($"t = {t}");
        }

        private static void ExpliziteDatentypkonvertierung()
        {
            // Explizite Datentypkonvertierung
            byte b = 65;
            char c = (char)b;
            Console.WriteLine($"c = {c}");

            double d = 245343.9999;
            int i = (int)d; // Beachte: Nachkommastellen werden einfach abgeschnitten und nicht gerundet
            Console.WriteLine($"i = {i}");
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void DatentypkonvertierungInStringMitToString()
        {
            // Datentypkonvertierung in string mit ToString()
            int a = 12;
            //string s = (string)a; // Error CS0030  Cannot convert type 'int' to 'string',
            // weil keine Konvertierung nicht programmiert ist in .NET
            // Quelle: https://softwareengineering.stackexchange.com/a/333428/5611
            string str = a.ToString();
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void DatentypkonvertierungVonStringNachInt()
        {
            // Datentypkonvertierung von string nach int
            string str = "200";
            int a = Int32.Parse(str); // Parst und konvertiert den string

            // Wirft im Fehlerfall eine System.FormatException
            string stringWithLetter = "200a";
            //int b = Int32.Parse(stringWithLetter); // Parst und konvertiert den string
            //Console.WriteLine(b);



            // Ein paar Console.WriteLine-Ausgaben, damit Visual Studio die Warnung "The variable 'a' is declared but never used" nicht mehr anzeigt
            Console.WriteLine(stringWithLetter);
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "InlineOutVariableDeclaration")]
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")] // Den kurz auskommentieren und schauen wie if-Klausel grau wird
        private static void DatentypkonvertierungMitTryParse()
        {
            // Datentypkonvertierung mit TryParse()
            string str = null; // "3927.21a" ausprobieren, um in den else-Teil zu gelangen
            double d;
            bool konvertierungWarErfolgreich = double.TryParse(str, out d);
            //bool konvertierungWarErfolgreich = double.TryParse(str, out double d); // Ab C# 7.0: inline out-variable declaration
            if (konvertierungWarErfolgreich)
            {
                Console.WriteLine($"Konvertierung war erfolgreich und der Wert von d ist {d}");
            }
            else
            {
                Console.WriteLine("Fehler: Falsches Format");
            }
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private static void DatentypkonvertierungMitKlasseConvert()
        {
            // Typ x nach Typ y mit Methoden der Klasse Convert
            //
            // Q: What is the difference between casting and Convert-class?
            // A: The Convert.ToInt32(String, IFormatProvider) underneath calls the Int32.Parse.
            // So the only difference is that if a null string is passed to Convert it returns 0,
            // whereas Int32.Parse throws an ArgumentNullException.
            //
            // Another difference I noted recently was that "Cast" casts 1.63 to 1, where as
            // "Convert" converts 1.63 to 2. So basically convert rounds as well as converts but
            // cast truncates values after the decimal point.
            //
            // Source: http://stackoverflow.com/a/3168730

            double d = 245343.92345;
            int i = Convert.ToInt32(d);
            decimal dec = Convert.ToDecimal(d);
            Console.WriteLine($"Ergebnis von Convert.ToInt32({d}): {i}");
            Console.WriteLine($"Ergebnis von Convert.ToDecimal({d}): {dec}");

            bool b = true;
            decimal decBoo = Convert.ToDecimal(b);
            Console.WriteLine($"Ergebnis von Convert eines Booleans: {decBoo}");
            //Console.WriteLine(Convert.ToDecimal(true)); // 1
            //Console.WriteLine(Convert.ToDecimal(false)); // 0
        }

        [SuppressMessage("ReSharper", "RedundantNameQualifier")]
        private static void SchlüsselwortTypeofUndMethodeGetType()
        {
            System.Type type = typeof(int);
            Console.WriteLine($"typeof(int) = {type}");

            int i = 0;
            System.Type type2 = i.GetType();
            Console.WriteLine($"i.GetType() = {type2}");
        }
    }
}