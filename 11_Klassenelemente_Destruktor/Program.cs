using System.Diagnostics.CodeAnalysis;

namespace _11_Klassenelemente_Destruktor
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
                    Destruktor();
                    break;
                case 2:
                    DestruktorMitDispose();
                    break;
                case 3:
                    DestruktorMitDisposeMitUsingSchreibweise();
                    break;
            }
        }

        [SuppressMessage("ReSharper", "NotAccessedVariable")]
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static void Destruktor()
        {
            var klasseMitDestruktor = new KlasseMitDestruktor();

            // Der Destruktor kann nicht direkt aufgerufen werden
            //klasseMitDestruktor.~KlasseMitDestruktor();

            // Beim Setzen auf null wird die Referenz auf das
            // Objekt gelöscht; Objekte, die nicht mehr referenziert
            // sind, werden vom Garbage Collector bei nächster
            // Gelegenheit aus dem Speicher entfernt
            klasseMitDestruktor = null;


            // Beachte: In der .NET Framework Version des Beispiels, würde man den Aufruf des Destruktors sehen.
            //          In dieser .NET 5.0 Version wird der Destruktor nicht aufgerufen. Siehe Stackoverflow
            //          https://stackoverflow.com/questions/44732234/why-does-the-finalize-destructor-example-not-work-in-net-core
        }

        private static void DestruktorMitDispose()
        {
            var klasseMitDestruktor = new KlasseMitDestruktorUndDispose();

            // Hier kann der Entwickler --sollte es nötig sein-- aktiv die
            // Aufräumarbeiten mit dem Aufruf von Dispose() auslösen, statt
            // auf den Garbage-Collector zu warten
            klasseMitDestruktor.Dispose();
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void DestruktorMitDisposeMitUsingSchreibweise()
        {
            using (var klasseMitDestruktor = new KlasseMitDestruktorUndDispose()) // using-Statement. (Der Eintrag ganz ober an der Klasse nennt sich using-Direktive.)
            {
                // ... Code ...

                // Hier muss das Dispose nicht mehr von Hand aufgerufen werden, weil per Definition
                // beim Verlassen des using-Blocks der Aufruf automatisch geschieht.
                //klasseMitDestruktor.Dispose(); // ← Ist nicht nötig
            }
        }
    }
}