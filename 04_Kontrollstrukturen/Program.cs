using System.Diagnostics.CodeAnalysis;

namespace _04_Kontrollstrukturen
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
                    IfElseOhneKlammern();
                    break;
                case 2:
                    IfElseOhneKlammernUndDieFehlerquelle();
                    break;
                case 3:
                    IfElseMitKlammern();
                    break;
                case 4:
                    IfElseIf();
                    break;
                case 5:
                    SwitchCase();
                    break;
                case 6:
                    WhileSchleife();
                    break;
                case 7:
                    DoWhileSchleife();
                    break;
                case 8:
                    ForSchleife();
                    break;
                case 9:
                    ForSchleifeUndIhreFehlerquelle();
                    break;
                case 10:
                    ForeachSchleife();
                    break;
            }
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private static void IfElseOhneKlammern()
        {
            // if-else-Kontrollstruktur ohne geschweifte Klammern (nicht empfohlen)
            int anzKarten = 36;
            if (anzKarten == 36) // In Klammern steht die Bedingung, die entweder "wahr" (true) oder "falsch" (false) sein kann
                Console.WriteLine("Neues Spiel");
            else
                Console.WriteLine("Karten spielen");
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private static void IfElseOhneKlammernUndDieFehlerquelle()
        {
            // if-else-Kontrollstruktur ohne geschweifte Klammern (nicht empfohlen)
            int anzKarten = 36;
            if (anzKarten > 40)
                Console.WriteLine("Neues Spiel");
            Console.WriteLine("Ich erwarte, dass diese Anweisung auch nur im if-Fall ausgeführt wird -- ist aber nicht der Fall und wird immer ausgeführt");
            // "Format document" ausführen, dann sieht man wie Visual Studio die obige Zeile richtig einrückt
            // Menü: Edit → Advanced → Format document (Ctrl+K, Ctrl+D)
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private static void IfElseMitKlammern()
        {
            // if-else-Konstrollstruktur mit geschweiften Klammern (empfohlen)
            int anzKarten = 36;
            if (anzKarten == 36)
            {
                Console.WriteLine("Neues Spiel");
            }
            else
            {
                Console.WriteLine("Karten spielen");
            }
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private static void IfElseIf()
        {
            // if-else-if-Konstrollstruktur
            int anzKarten = 36;
            if (anzKarten == 36)
            {
                Console.WriteLine("Neues Spiel");
            }
            else if (anzKarten == 0)
            {
                Console.WriteLine("Spielende");
            }
            else
            {
                Console.WriteLine("Karte spielen");
            }
        }

        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        private static void SwitchCase()
        {
            // switch-Konstrollstruktur
            int anzKarten = 20;
            switch (anzKarten)
            {
                case 36:
                    Console.WriteLine("Neues Spiel");
                    break;  // break ist zwingend; geht es vergessen, zeigt der Compiler einen Error an
                case 20:
                case 10:
                    Console.WriteLine("Dieser Text erscheint für die Fälle 10 und 20");
                    break;
                case 0:
                    Console.WriteLine("Spielende");
                    break;
                default:
                    Console.WriteLine("Karten spielen");
                    break;
            }
        }

        private static void WhileSchleife()
        {
            // while-Schleife: Bedingung wird schon vor der ersten Durchführung geprüft, d.h. die Schleife
            // kann potentiell auch keinmal / nullmal durchlaufen werden
            int i = 0;
            while (i <= 10)
            {
                Console.WriteLine(i);
                i = i + 1;
            }
        }

        private static void DoWhileSchleife()
        {
            // do-while-Schleife: Bedingung wird erst nach der ersten Durchführung geprüft, d.h. die Schleife
            // läuft immer mindestens einmal durch
            int i = 0;
            do
            {
                Console.WriteLine(i);
                i = i + 1;
            } while (i <= 10);
        }

        private static void ForSchleife()
        {
            // for-Schleife: verwenden, wenn man auf eine Zählvariable i angewiesen ist, sonst foreach-Schleife
            // verwenden
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        private static void ForSchleifeUndIhreFehlerquelle()
        {
            // for-Schleife: Eine Gefahr ist, dass man bei Arrays über die Index-Grenze hinweg gehen kann,
            // was zu einer IndexOutOfRangeException führt
            int[] list = { 1, 2, 3 };
            for (int index = 0; index < 4; index++)
            {
                int i = list[index];
                Console.WriteLine($"Index = {index}, Wert = {i}");
            }

            // Ausgabe:
            // Unhandled Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.
            //    at 30_Kontrollstrukturen.Program.Main(String[] args) in C:\...\03_Kontrollstrukturen\Program.cs:line 129

            // Stabilere Version mit list.Length
            //int[] list = { 1, 2, 3 };
            //for (int index = 0; index < list.Length; index++)
            //{
            //    int i = list[index];
            //    Console.WriteLine($"Index = {index}, Wert = {i}");
            //}

            // Noch bessere Version mit foreach (wenn man den Index nicht benötigt)
        }

        private static void ForeachSchleife()
        {
            // foreach-Schleife
            int[] listeVonWerten = { 1, 2, 3 };
            foreach (int derAktuelleWert in listeVonWerten)
            {
                Console.WriteLine(derAktuelleWert);
            }
        }
    }
}
