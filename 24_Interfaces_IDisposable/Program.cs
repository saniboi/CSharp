using System.Diagnostics.CodeAnalysis; // using-Direktive: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using

namespace _24_Interfaces_IDisposable
{
    public class Program
    {
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {

            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    Variante1OhneUsingAnweisung();
                    break;
                case 2:
                    Variante1MitUsingAnweisung();
                    break;
                case 3:
                    Variante3WieManEineUsingAnweisungVonHandProgrammierenMüsste();
                    break;
                case 4:
                    Variante4WeitereMöglicheSchreibweiseAbCSharp8();
                    break;
            }
        }

        private static void Variante1OhneUsingAnweisung()
        {
            Console.WriteLine("--- Variante 1 ohne using-Statement ---");

            var ressourcenFressendesObjekt = new RessourcenFressendeKlasse();
            // Hier irgend etwas mit der ressourcenFressendeKlasse tun...
            ressourcenFressendesObjekt.Dispose(); // Ich starte aktiv die Aufräumarbeiten via Dispose() (weil ich den Destruktor nicht aktiv aufrufen kann)

            Console.WriteLine();
        }

        private static void Variante1MitUsingAnweisung()
        {
            Console.WriteLine("--- Variante 2 mit using-Statement ---"); // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement

            using (RessourcenFressendeKlasse ressourcenFressendesObjekt = new RessourcenFressendeKlasse())
            {
                // Hier irgend etwas mit der ressourcenFressendesObjekt tun...
            } // Beim Verlassen des Gültigkeitsbereichs wird automatisch Dispose() aufgerufen

            Console.WriteLine();
        }

        [SuppressMessage("ReSharper", "UseNullPropagation")]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private static void Variante3WieManEineUsingAnweisungVonHandProgrammierenMüsste()
        {
            Console.WriteLine("--- Variante 3 wie man es vor der Erfindung des using-Statements geschrieben hat ---");
            // Die using-Syntax oben ist gleichbedeutend mit
            var ressourcenFressendesObjekt = new RessourcenFressendeKlasse();
            try
            {
                // Hier irgend etwas mit der ressourcenFressendesObjekt tun...
            }
            finally
            {
                if (ressourcenFressendesObjekt != null)
                {
                    ((IDisposable)ressourcenFressendesObjekt).Dispose();
                }
            }
            // Quelle
            // - https://stackoverflow.com/questions/20703500/try-finally-block-vs-calling-dispose
            // - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement
        }

        private static void Variante4WeitereMöglicheSchreibweiseAbCSharp8()
        {
            // Neue Schreibweise ab C# 8.0 (2019)
            // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations
            // https://stackoverflow.com/a/212210
            // Nutzen: vereinfachte Schreibeweise, weil man die beiden geschweiften Schleifen nicht mehr benötigt und somit
            //         eine Verschachtelungstiefe weniger hat. Wenn z.B. 3 usings geschachtelt würden, hätte man früher 3
            //         Verschachtelungstiefen gehabt, die jetzt auf eine reduziert werden kann.

            using var ressourcenFressendesObjekt = new RessourcenFressendeKlasse(); // Hier ist das ganze try-finally-Konstrukt von oben enthalten!
            // Hier irgend etwas mit der ressourcenFressendesObjekt tun...
        } // Beim Verlassen des Gültigkeitsbereichs wird automatisch Dispose() aufgerufen
          // Resharper zeigt die Information auch mit dem Text "using var ressourcenFressendesObjekt" als Overlay an
    }
}