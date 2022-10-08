using System.Diagnostics.CodeAnalysis;

namespace _08_Operatoren
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
                    UnäreOperatoren();
                    break;
                case 2:
                    BinäreOperatoren();
                    break;
                case 3:
                    ArithmetischeOperatoren();
                    break;
                case 4:
                    Vergleichsoperatoren();
                    break;
                case 5:
                    LogischeOperatoren();
                    break;
                case 6:
                    BitweiseOperatoren();
                    break;
                case 7:
                    ZuweisungsoperatorenTeil1Von2();
                    break;
                case 8:
                    ZuweisungsoperatorenTeil2Von2();
                    break;
                case 9:
                    SonstigeOperatorenTeil1Von3();
                    break;
                case 10:
                    SonstigeOperatorenTeil2Von3();
                    break;
                case 11:
                    SonstigeOperatorenTeil3Von3();
                    break;
            }
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "LoopVariableIsNeverChangedInsideLoop")]
        private static void UnäreOperatoren()
        {
            int negativerWerte = -1; // Beachte: Das Negativzeichen kann auch ein binärer Operator sein, kann also in beiden Kategorien sein
                                     // Beispiel int differenz = 2 - 3;
            bool istFalsch = !true;  // Beachte für später:
                                     // "= !" ist eine Zuweisung eines negierten boolschen Wertes; Beispiel: ergebnis = !benutzereingabeIstValid;
                                     // "!=" hingegen ist eine Prüfung auf Ungleichheit; Beispiel: if (a != b) {...}

            Console.WriteLine($"negativerWerte: {negativerWerte}");
            Console.WriteLine($"istFalsch: {istFalsch}");

            // Anwendungsbeispiel für ein Negation "!"
            bool benutzereingabeIstValid = false;
            do
            {
                // Eingabe vom Benutzer wiederholt verlangen, ...
            } while (!benutzereingabeIstValid); // ...solange die Eingabe NICHT valide ist
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "RedundantIfElseBlock")]
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        [SuppressMessage("ReSharper", "RedundantBoolCompare")]
        private static void BinäreOperatoren()
        {
            int summe = 1 + 2;

            bool isReadOnly = true;
            bool resultat = isReadOnly == true;

            Console.WriteLine($"summe: {summe}");
            Console.WriteLine($"resultat: {resultat}");

            //// Beispiel mit "== true": das Ausschreiben kann am Anfang des Lernens die Lesbarkeit erhöhen
            //if (isReadOnly == true)
            //{
            //    // Etwas machen
            //} else if (isReadOnly == false)
            //{
            //    // Etwas anderes machen
            //}

            //// Beispiel ohne "== true": so macht man später in echten Kundenprojekten
            if (isReadOnly)
            {
                // Etwas machen
            }
            else // else if (!isReadyOnly)
            {
                // Etwas anderes machen
            }
        }

        [SuppressMessage("ReSharper", "UseFormatSpecifierInInterpolation")]
        private static void ArithmetischeOperatoren()
        {
            Console.WriteLine($"2 + 4 : {2 + 4}");
            Console.WriteLine($"+4 : {+4}");
            Console.WriteLine($"+4 : {(+4).ToString("+#;-#;0")}"); // Anzeige des Pluszeichens erzwingen: http://stackoverflow.com/a/348242/33311
            Console.WriteLine($"6 - 4 : {6 - 4}");
            Console.WriteLine($"-9 : {-9}");
            Console.WriteLine($"6 * 4 : {6 * 4}");
            Console.WriteLine($"10 / 2 : {10 / 2}");
            Console.WriteLine($"7 % 2 : {7 % 2}");  // Der %-Operator heisst Modulo-Operator und gibt den ganzzahligen Rest der Divison
                                                    // Kann man z.B. verwenden, um zu überprüfen, ob eine Zahl x durch eine Zahl y teilbar ist
            Console.WriteLine($"10 / 2 : {10 / 2}");
            //Console.WriteLine(1++);               // Das geht nicht; the operand of an increment or decrement operator must be a variable, property or indexer


            int a = 1;
            int b = 1;
            Console.WriteLine($"a : {a}");
            Console.WriteLine($"b : {b}");

            int c = ++a; // Zuerst a inkrementieren, dann den neuen Wert in c schreiben, d.h c ist =2
            int d = b++; // Zuerst b ins d schreiben, dann b inkrementieren, d.h. d ist = 1
            Console.WriteLine($"a : {a}");
            Console.WriteLine($"b : {b}");
            Console.WriteLine($"c : {c}");
            Console.WriteLine($"d : {d}");
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private static void Vergleichsoperatoren()
        {
            int a = 1;
            int b = 2;
            Console.WriteLine($"a: {a}");
            Console.WriteLine($"b: {b}");
            Console.WriteLine($"a == b: {a == b}");
            Console.WriteLine($"a != b: {a != b}");
            Console.WriteLine($"a < b: {a < b}");
            Console.WriteLine($"a > b: {a > b}");
            Console.WriteLine($"a <= b: {a <= b}");
            Console.WriteLine($"a >= b: {a >= b}");
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private static void LogischeOperatoren()
        {
            bool a = true;
            bool b = false;
            Console.WriteLine($"a : {a}");
            Console.WriteLine($"b : {b}");
            Console.WriteLine($"!a : {!a}");
            Console.WriteLine($"a && b : {a && b}");
            Console.WriteLine($"a || b : {a || b}");
            Console.WriteLine($"a ^ b : {a ^ b}"); // XOR, exclusive OR:  It yields true if exactly one (but not both) of two conditions is true.
            Console.WriteLine($"true ^ true : {true ^ true}");        // T ^ T ist F
            Console.WriteLine($"true ^ false : {true ^ false}");      // T ^ F ist T
            Console.WriteLine($"false ^ true : {false ^ true}");      // F ^ T ist T
            Console.WriteLine($"false ^ false : {false ^ false}");    // F ^ F ist F
        }

        private static void BitweiseOperatoren()
        {
            Console.WriteLine(" 8 = {0,8}", Convert.ToString(8, 2).PadLeft(32, '0'));
            Console.WriteLine("~8 = {0,8}", Convert.ToString(~8, 2));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    5 = {0}", Convert.ToString(5, 2).PadLeft(32, '0'));
            Console.WriteLine("    7 = {0}", Convert.ToString(7, 2).PadLeft(32, '0'));
            Console.WriteLine("5 | 7 = {0}", Convert.ToString(5 | 7, 2).PadLeft(32, '0'));
            Console.WriteLine("    7 = {0}", Convert.ToString(7, 2).PadLeft(32, '0'));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    3 = {0}", Convert.ToString(3, 2).PadLeft(32, '0'));
            Console.WriteLine("    6 = {0}", Convert.ToString(6, 2).PadLeft(32, '0'));
            Console.WriteLine("3 & 6 = {0}", Convert.ToString(3 & 6, 2).PadLeft(32, '0'));
            Console.WriteLine("    2 = {0}", Convert.ToString(2, 2).PadLeft(32, '0'));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    4 = {0}", Convert.ToString(4, 2).PadLeft(32, '0'));
            Console.WriteLine("    5 = {0}", Convert.ToString(5, 2).PadLeft(32, '0'));
            Console.WriteLine("4 ^ 5 = {0}", Convert.ToString(4 ^ 5, 2).PadLeft(32, '0'));
            Console.WriteLine("    1 = {0}", Convert.ToString(1, 2).PadLeft(32, '0'));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     8 = {0}", Convert.ToString(8, 2).PadLeft(32, '0'));
            Console.WriteLine("     2 = {0}", Convert.ToString(2, 2).PadLeft(32, '0'));
            Console.WriteLine("8 << 2 = {0}", Convert.ToString(8 << 2, 2).PadLeft(32, '0'));
            Console.WriteLine("    32 = {0}", Convert.ToString(32, 2).PadLeft(32, '0'));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     8 = {0}", Convert.ToString(8, 2).PadLeft(32, '0'));
            Console.WriteLine("     1 = {0}", Convert.ToString(1, 2).PadLeft(32, '0'));
            Console.WriteLine("8 >> 1 = {0}", Convert.ToString(8 >> 1, 2).PadLeft(32, '0'));
            Console.WriteLine("     4 = {0}", Convert.ToString(4, 2).PadLeft(32, '0'));

            Console.WriteLine();
            Console.WriteLine();
        }

        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static void ZuweisungsoperatorenTeil1Von2()
        {
            int x = 2;
            Console.WriteLine("x  = {0} => x = {0}", x);
            Console.WriteLine("x += 1 => x = {0}", x += 1); // Entspricht x = x + 1
            Console.WriteLine("x -= 1 => x = {0}", x -= 1); // Entspricht x = x - 1
            Console.WriteLine("x *= 2 => x = {0}", x *= 2); // Entspricht x = x * 2
            Console.WriteLine("x /= 2 => x = {0}", x /= 2); // Entspricht x = x / 2

            Console.WriteLine();
            Console.WriteLine();
            x = 8;
            Console.WriteLine("x  = {0} => x = {0}", x);
            Console.WriteLine("x %= 3 => {0}", x %= 3);     // Entspricht x = x % 3

            Console.WriteLine();
            Console.WriteLine();
            x = 4;
            Console.WriteLine("x ^=  5, mit x = 4 => x =  {0}", x ^= 5);    // Entspricht x = x ^ 5
            x = 8;
            Console.WriteLine("x <<= 2, mit x = 8 => x = {0}", x <<= 2);    // Entspricht x = x << 2
            x = 8;
            Console.WriteLine("x >>= 1, mit x = 8 => x =  {0}", x >>= 1);   // Entspricht x = x >> 1

            Console.WriteLine();
            Console.WriteLine();
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static void ZuweisungsoperatorenTeil2Von2()
        {
            bool x = true;
            bool y = false;
            Console.WriteLine("x  = {0}", x);
            Console.WriteLine("y  = {0}", y);
            Console.WriteLine("x &= y => {0}", x &= y);
            x = true;
            y = false;
            Console.WriteLine("x |= y => {0}", x |= y);
            Console.WriteLine();
            Console.WriteLine();
        }

        [SuppressMessage("ReSharper", "RedundantAssignment")]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "IsExpressionAlwaysTrue")]
        private static void SonstigeOperatorenTeil1Von3()
        {
            int x = 1;
            Console.WriteLine(Math.Sin(x)); // Punkt-Operator zwischen Math und Sin

            int[] myArray = { 1, 2, 3 };
            Console.WriteLine(myArray[2]);  // Eckige Klammern

            //[Obsolete("Don't use Old method, use New method", true)] // Attribute in eckigen Klammern https://stackoverflow.com/questions/2968597/what-is-brackets-in-net
            //static void Old() { }

            Console.WriteLine((2 + 3) * 5);
            int y = 1;
            x = y == 1 ? 2 : 3; // Ternery operator; Elvis-Operator; ist gleichbedeutend mit dem if-else-Konstrukt unten
            if (y == 1)
            {
                x = 2;
            }
            else
            {
                x = 3;
            }
            // Bei kurzen Ausdrücken ist der ?:-Operator sinnvoll, bei längeren
            // lieber if-else verwenden, wegen der besseren Lesbarkeit


            char[] charArray = { 'H', 'e', 'l', 'l', 'o', ',', ' ', 'W', 'o', 'r', 'l', 'd', '!' }; // Array-[]-Operator
            string s = new String(charArray);   // new-Operator
            Console.WriteLine(s);

            // is-Operator
            if (s != null)
            {
                Console.WriteLine("s ist vom Type String.");
            }

            Console.WriteLine(typeof(int)); // typeof-Operator
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void SonstigeOperatorenTeil2Von3()
        {
            checked // Der Überlauf des Wertebereichs wird detektiert und es wird eine
                    // System.OverflowException geworfen. Das ist gut, weil man über den
                    // Fehler informiert wird.
            {
                byte a = 55;
                byte b = 210;
                byte c = (byte)(a + b);
            }

            // Um "checked" für das ganze Projekt einzuschalten:
            // Projekt-Properties > Lasche: Build > Knopf: Advanced... > Häkchen bei: Check for arithmetic overflow/underflow
            // Dokumentation: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/checked-compiler-option
        }

        private static void SonstigeOperatorenTeil3Von3()
        {
            unchecked // Der Überlauf des Wertebereichs geschieht im Stillen und es resultieren falsche Ergebnisse, ohne
                      // dass man etwas davon merkt!
            {
                byte a = 55;
                byte b = 210;
                byte c = (byte)(a + b);
                Console.WriteLine($"a = {a}");
                Console.WriteLine($"b = {b}");
                Console.WriteLine($"c = (byte)(a + b) = {c}");
            }
        }
    }
}
