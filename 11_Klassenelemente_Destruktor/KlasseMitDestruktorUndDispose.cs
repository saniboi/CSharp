namespace _11_Klassenelemente_Destruktor
{
    public class KlasseMitDestruktorUndDispose : IDisposable
    {
        private int anzahlStattgefundenerDisposeAufrufe = 0;

        ~KlasseMitDestruktorUndDispose()
        {
            // Statt die Ressourcen direkt im Destruktor freizugeben
            // die Aufgaben an die Methode Dispose() delegieren
            Dispose();
        }

        public void Dispose()
        {
            anzahlStattgefundenerDisposeAufrufe++;

            // Anweisungen, um Ressourcen freizugeben
            Console.WriteLine($"Ressourcen freigeben... {anzahlStattgefundenerDisposeAufrufe}x");

            // Beachte, dass der Code hier idempotent geschrieben werden muss.
            // D.h. er soll auch funktionieren, wenn Dipose() mehrfach aufgerufen
            // wird. Das kann geschehen, wenn der Entwickler Dispose() direkt aufruft
            // und später der Deskruktor den gleichen Aufruf nochmals macht.
            // Siehe Konsolenoutput, um den zweifachen Auruf zu sehen.
        }
    }
}