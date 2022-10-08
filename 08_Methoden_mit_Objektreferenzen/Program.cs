namespace _08_Methoden_mit_Objektreferenzen
{
    internal class Program
    {
        public static void Main()
        {
            var bike = new Bike
            {
                Id = 1,
                Brand = "PowerRacer",
                Model = "Storm 4",
                PurchasePrice = 2500,
                PurchaseDate = new DateTime(2016, 8, 1)
            };

            Console.WriteLine("--- Bike-Werte vor dem Methodenaufruf ---");
            Console.WriteLine(bike);
            CalculateResalePrice(bike);
            Console.WriteLine("\n--- Bike-Werte nach dem Methodenaufruf ---");
            Console.WriteLine(bike); // Beachte: bisher hatten Variablenänderungen innerhalb einer Methode keine
            // Auswirkungen nach aussen (ausser bei ref und out natürlich).
            // Jetzt bei Objekten hat es aber sehr wohl --und auch gewollt-- eine Auswirkung
            // ausserhalb der Methode.
        }

        private static void CalculateResalePrice(Bike bike)
        {
            TimeSpan timeSpan = DateTime.Now - bike.PurchaseDate;
            double minFactor = (timeSpan.TotalDays / 365) >= 5 ? 0 : (timeSpan.TotalDays / 365) * 0.2;
            double maxFactor = (timeSpan.TotalDays / 365) >= 5 ? 0 : (timeSpan.TotalDays / 365) * 0.15;
            bike.ResalePriceMin = bike.PurchasePrice * (1 - minFactor);
            bike.ResalePriceMax = bike.PurchasePrice * (1 - maxFactor);
        }
    }
}