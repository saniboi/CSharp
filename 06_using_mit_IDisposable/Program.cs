using System.Diagnostics.CodeAnalysis;

namespace _06_using_mit_IDisposable
{
    public class Program
    {
        public static void Main()
        {
            BeispielMitUsing();
            BeispielOhneUsing();
        }

        public class MeineRessource : IDisposable  // Wenn man das ": IDisposable" löscht, meldet der Compiler unten beim using
                                                   // "Type used in a using statement must be implicitely convertible to System.IDisposible"
                                                   // Das ist ein schöner Anwendungsfall, wie man mit einem Interface einen Vertrag
                                                   // erzwingen kann und Code gegen das Interface schreiben kann
        {
            public void MachEtwas()
            {
                Console.WriteLine("Mach irgendwas.");
            }

            public void Dispose()
            {
                Console.WriteLine("Dispose() mit Aufräumarbeiten.");
            }
        }

        /// <summary>
        /// Explanation: http://www.codeproject.com/Articles/6564/Understanding-the-using-statement-in-C
        /// </summary>
        private static void BeispielMitUsing()
        {
            using (MeineRessource meineRessource = new MeineRessource()) // Mit Resharper den "convert to 'using' declaration"-Fix
                                                                         // ausprobiere und schauen, wie der Code dann aussieht
            {
                meineRessource.MachEtwas();
            } // Hier wird Dispose() aufgerufen; siehe Konsolenausgabe zur Kontrolle
        }

        [SuppressMessage("ReSharper", "UseNullPropagation")]
        private static void BeispielOhneUsing()
        {
            // Der using-Ausdruck von oben in der BeispielMitUsing()-Methode wird beim Kompilieren in folgendes try-finally-Konstrukt umgewandelt

            MeineRessource meineRessource2 = new MeineRessource();
            try
            {
                meineRessource2.MachEtwas();
            }
            finally
            {
                // Check for a null
                if (meineRessource2 != null)
                {
                    // Call the object's Dispose()-method.
                    ((IDisposable)meineRessource2).Dispose(); // Hier wird Dispose() aufgerufen.
                                                              // Darum muss auch das Objekt das IDisposeable-Interface implementieren.
                }
            }
        }
    }
}