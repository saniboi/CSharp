using System;

namespace _20_BookInventory_MVVM_Example_5.DataAccessLayer
{
    public class BookRepository
    {
        readonly Random random = new Random();
        readonly string[] titles = { "C# Programmieren", "Clean Code", "Design Patterns", ".NET Framework", "WPF Programmieren" };
        readonly string[] authors = { "Jack Bauer", "Steven King", "Roy Hackman", "Bill Dcom", "Donald Duck" };
        readonly decimal[] prices = { 12.95m, 39.90m, 24.90m, 29.50m };

        public string GetRandomBookTitles
        {
            get { return titles[random.Next(titles.Length)]; }
        }

        public string GetRandomAuthors
        {
            get { return authors[random.Next(authors.Length)]; }
        }

        public decimal GetRandomPrices
        {
            get { return prices[random.Next(prices.Length)]; }
        }
    }
}