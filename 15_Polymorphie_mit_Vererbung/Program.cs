namespace _15_Polymorphie_mit_Vererbung
{
    public class Program
    {
        public static void Main()
        {
            PolymorphieBeiToString();
            //PolymorphieBeiEigenenKlassen();
        }

        private static void PolymorphieBeiToString()
        {
            // Zuerst die ToString-Methoden in Haustier, Hund und Katze auskommentieren
            // und das Beispiel unten laufen lassen.

            // Dann die ToString-Methoden in Haustier, Hund und Katze nacheinandern wieder
            // aktivieren und das Beispiel unten nochmals laufen lassen und den Unterschied
            // anschauen.

            var haustier = new Haustier();
            var hund = new Hund();
            var katze = new Katze();

            Console.WriteLine(haustier);    // Es wird polymorph die ToString()-Methode aufgerufen
            Console.WriteLine(hund);        // Es wird polymorph die ToString()-Methode aufgerufen
            Console.WriteLine(katze);       // Es wird polymorph die ToString()-Methode aufgerufen
        }

        private static void PolymorphieBeiEigenenKlassen()
        {
            // Zuerst die ToString-Methoden in Haustier, Hund und Katze auskommentieren
            // und das Beispiel unten laufen lassen.

            // Dann die ToString-Methoden in Haustier, Hund und Katze wieder aktivieren
            // und das Beispiel unten nochmals laufen lassen und den Unterschied anschauen.

            var haustier = new Haustier();
            var hund = new Hund();
            var katze = new Katze();

            // Bis jetzt hat uns Polymorphie noch nicht wahnsinnig viel gebracht.
            // Interessant wird es, wenn wir Methoden haben, die etwas tun, und nun
            // in der Lage sind, für alle Arten von Haustieren etwas zu tun (siehe Methode TiergeräuschMachen()),
            // aber immer leicht anders, abhängig davon, was für ein Haustier als Argument
            // übergeben wird.

            Console.WriteLine($"haustier.MachGeräusch() : {TiergeräuschMachen(haustier)}");    // Es wird polymoph die MachGeräusch()-Methode aufgerufen
            Console.WriteLine($"hund.MachGeräusch()     : {TiergeräuschMachen(hund)}");        // Es wird polymoph die MachGeräusch()-Methode aufgerufen
            Console.WriteLine($"katze.MachGeräusch()    : {TiergeräuschMachen(katze)}");       // Es wird polymoph die MachGeräusch()-Methode aufgerufen
        }

        /// <summary>
        /// Mehrwert von Polymorphie:
        /// 
        /// Diese Methode kann mit allen Arten von Haustieren umgehen und muss nicht angefasst werden,
        /// wenn wir einen neuen Typ von Haustier hinzufügen.
        /// </summary>
        /// <param name="haustier">Die Haustier-Instanz, von der wir das Geräusch haben wollen.</param>
        /// <returns>Das Geräusch, welches ein spezifisches Haustier macht.</returns>
        private static string TiergeräuschMachen(Haustier haustier)
        {
            return haustier.MachGeräusch();
        }
    }
}