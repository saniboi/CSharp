namespace _24_Interfaces_IDisposable
{
    public class RessourcenFressendeKlasse : IDisposable
    {
        ~RessourcenFressendeKlasse()
        {
            Console.WriteLine("Destruktor wird ausgeführt...");
            Dispose(); // Dispose aus dem Desktruktor aufrufen
        }

        /// <summary>
        /// Dispose() wird vom GarbageCollector nicht automatisch aufgerufen, der GarbageCollector ruft nur den Destruktor auf:
        /// https://stackoverflow.com/a/1691850/33311
        /// 
        /// Von der using()-Anweisung wird die Dispose()-Methode aufgerufen.
        /// </summary>
        public void Dispose()
        {
            // Beachte: Dieser Code wird potentiell zweimal aufgerufen. Einmal vom Destruktor und einmal vom Entwickler direkt
            //          oder indirekt via using()-Anweisung.
            Console.WriteLine("Dispose() wird ausgeführt... Aufräumarbeiten ausführen.");
        }
    }
}