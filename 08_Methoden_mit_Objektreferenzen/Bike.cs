namespace _08_Methoden_mit_Objektreferenzen
{
    internal class Bike
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double ResalePriceMin { get; set; }
        public double ResalePriceMax { get; set; }

        public override string ToString()
        {
            return
                $"{Id}: {Brand}, {Model}, Purchase: {PurchaseDate.ToShortDateString()}, {PurchasePrice:C2}, Resale [min: {ResalePriceMin:C2}, max: {ResalePriceMax:C2}]";
        }
    }
}