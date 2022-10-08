using System.Diagnostics.CodeAnalysis;

namespace _02_throw
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
                    ThrowException();
                    break;
                case 2:
                    ThrowMitE_MeistensSchlecht();
                    break;
                case 3:
                    ThrowOhneE_MeistensBesser();
                    break;
            }
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private static void ThrowException()
        {
            int minute = -1;
            if (minute < 1 || minute > 59)
            {
                string exceptionMessage = $"Minute '{minute}' ist keine gültige Minute.";
                throw new ArgumentException(exceptionMessage);
                Console.WriteLine("test");  // Dieser Code wird nie ausgeführt,
                                            // weil der Programmfluss nach dem throw
                                            // einen anderen Weg nimmt
            }
        }

        private static void ThrowMitE_MeistensSchlecht()
        {
            try
            {
                FileInfo source = new FileInfo("code.cs");
                int length = (int)source.Length; // Hier wird die Exception geworfen
            }
            catch (IOException e)
            {
                Console.WriteLine("Hier Aufräumarbeiten durchführen...");
                throw e; // Exception weiterwerfen an die nächst höhere Instanz.
                         // Aber bei throw e wird der Stacktrace abgeschnitten
                         // und es sieht so aus, als stamme die Exception ursprünglich
                         // aus unserer Methode ThrowMitE_MeistensSchlecht().

                // Stacktrace
                // Unhandled Exception: System.IO.FileNotFoundException: Could not find file 'code.cs'.
                // at _02_throw.Program.ThrowMitE_MeistensSchlecht() in C:\temp\Program.cs:line 39
                // at _02_throw.Program.Main(String[] args) in C:\temp\Program.cs:line 12
                // Press any key to continue . . .
            }
        }

        private static void ThrowOhneE_MeistensBesser()
        {
            try
            {
                FileInfo source = new FileInfo("code.cs");
                int length = (int)source.Length; // Hier wird die Exception geworfen
            }
            catch (IOException e)
            {
                Console.WriteLine("Hier Aufräumarbeiten durchführen...");
                throw; // Exception weiterwerfen an die nächst höhere Instanz.
                       // Bei throw _ohne_ e wird der ganze Stacktrace weitergegeben,
                       // was mehr Informationen liefert und meistens die bessere
                       // Wahl ist gegenüber "throw e".

                // Stacktrace
                // Unhandled Exception: System.IO.FileNotFoundException: Could not find file 'code.cs'.
                // at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
                // at System.IO.FileInfo.get_Length()
                // at _02_throw.Program.ThrowOhneE_MeistensBesser() in C:\temp\Program.cs:line 62
                // at _02_throw.Program.Main(String[] args) in C:\temp\Program.cs:line 13
                // Press any key to continue . . .
            }
        }
    }
}