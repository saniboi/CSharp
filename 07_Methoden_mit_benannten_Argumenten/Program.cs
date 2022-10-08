namespace _07_Methoden_mit_benannten_Argumenten
{
    internal class Program
    {
        public static void Main()
        {
            DefaultValueVerwenden();
            DefaultValueErsetzen();
            ArgumentBenennen();
        }

        private static void DefaultValueVerwenden()
        {
            double price = 80;
            double amount = GetPriceWithTransportTax(price); // Nur ein Argument wird mitgeschickt,
            // obwohl die Methode zwei Argumente erwartet
            // Dann wird  für 'limit' der Standardwert von 100 genommen
            Console.WriteLine($"Preis: {price:C2}, mit Transportkosten: {amount:C2}");
        }

        private static void DefaultValueErsetzen()
        {
            double price = 80;
            double amount = GetPriceWithTransportTax(price, 70); // Hier wird der Standardwert von 100 mit 70 ersetzt
            Console.WriteLine($"Preis: {price:C2}, mit Transportkosten: {amount:C2}");
        }

        private static void ArgumentBenennen()
        {
            double price = 80;
            double amount = GetPriceWithTransportTax(limit: 70, price: price); // Hier haben wir die Argumente benannt
            // und auch noch gleich die Reihenfolge verändert
            Console.WriteLine($"Preis: {price:C2}, mit Transportkosten: {amount:C2}");
        }

        private static double GetPriceWithTransportTax(double price, double limit = 100)
        {
            return price >= limit ? price : price + 10.5;
        }
    }
}