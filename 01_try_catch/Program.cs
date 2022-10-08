using System.Diagnostics.CodeAnalysis;
using System.Security;
#pragma warning disable 168

namespace _01_try_catch
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
                    OhneTryCatch();
                    break;
                case 2:
                    MitTryCatch();
                    break;
                case 3:
                    TryCatchDemoMitMehrerenCatch();
                    break;
            }
        }

        private static void OhneTryCatch()
        {
            string s = "Kein int-Wert";
            int i = int.Parse(s);
            Console.WriteLine($"i = {i}"); // Diese Zeile wird nie erreicht
        }

        private static void MitTryCatch()
        {
            string s = "Kein int-Wert";

            int i;
            try
            {
                i = int.Parse(s);
                Console.WriteLine($"i = {i}"); // Diese Zeile wird nie erreicht
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Variable 's' mit dem Wert '{s}' ist keine gültige Integerzahl.");
                Console.WriteLine($"Der Ausnahmefall ist vom Typ: {e.GetType().FullName}");
                Console.WriteLine();
                Console.WriteLine("Die Fehlermeldung des Ausnahmefalls lautet wie folgt:");
                Console.WriteLine(e);
            }
        }

        private static void TryCatchDemoMitMehrerenCatch()
        {
            try
            {
                Console.WriteLine("1");
                FileInfo source = new FileInfo("code.cs");
                Console.WriteLine("2");
                int length = (int)source.Length; // Hier wird die Exception geworfen
                Console.WriteLine("3"); // Der Code ab hier wird nicht mehr ausgeführt!
                char[] contents = new char[length];
                Console.WriteLine("4");
                Console.WriteLine(contents);
            }
            catch (SecurityException e) // Immer die konkreteste Exception zuerst abfangen; die allgemeineren weiter unten
            {
                Console.WriteLine("SecurityException e");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (IOException e)
            {
                Console.WriteLine("IOException e");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine("OutOfMemoryException e");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                // Regel: Nie eine leere catch-Klause schreiben wie diese hier.
                //
                // Damit schluckt man Ausnahmefälle und der Entwickler/Benutzer merkt nicht
                // das gerade etwas schiefgegangen ist.
                //
                // Lieber abstürzen und merken, dass etwas nicht in Ordnung ist, als das
                // Programm weiterlaufen zu lassen und falsche Werte zu berechnen.
            }
            catch // catch ohne Parameter fängt alle Exceptions
            {
                Console.WriteLine("catch all");
            }
        }
    }
}