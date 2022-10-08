using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace _07_HashTable
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 2;

            switch (beispiel)
            {
                case 1:
                    HastableBeispiel();
                    break;
                case 2:
                    SortedListBeispiel();
                    break;
            }
        }

        private static void HastableBeispiel()
        {
            IDictionary hashtable = new Hashtable(); // Ist ein IDictionary
            hashtable[1] = "Eins";
            hashtable[2] = "Zwei";
            hashtable[13] = "Dreizehn";
            hashtable[13] = "Hello World";

            Console.WriteLine("--- foreach: Hashtable");
            Console.WriteLine("<Key>: <Value>");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        private static void SortedListBeispiel()
        {
            SortedList table = new SortedList(); // Ist ein IDictionary

            // Wenn wir die Deklaration in 
            // IDictionary table = new SortedList();
            // ändern, wird das IndexOfKey() unten nicht
            // funktionieren, weil das nur auf SortedList
            // existiert und nicht auf dem Interface
            // IDictionary.

            Console.WriteLine("\n--- SortedList ---");
            table["Keith"] = 42;
            table["Aaron"] = 35;
            table["Fritz"] = 37;
            //table["Fritz"] = 40; // Überschreibt den vorherigen Eintrag

            Console.WriteLine($"Keith befindet sich bei Index {table.IndexOfKey("Keith")}.");
            Console.WriteLine($"Aaron befindet sich bei Index {table.IndexOfKey("Aaron")}.");
            Console.WriteLine($"Fritz befindet sich bei Index {table.IndexOfKey("Fritz")}.");
            Console.WriteLine();

            Console.WriteLine($"Keith ist {table["Keith"]} Jahre alt.");
            Console.WriteLine($"Aaron ist {table["Aaron"]} Jahre alt.");
            Console.WriteLine($"Fritz ist {table["Fritz"]} Jahre alt.");
            Console.WriteLine();

            Console.WriteLine($"table.ContainsKey(\"Hans\"): {table.ContainsKey("Hans")}");
            Console.WriteLine($"table.ContainsKey(\"Aaron\"): {table.ContainsKey("Aaron")}");
            Console.WriteLine();

            Console.WriteLine($"GetByIndex(2): {table.GetByIndex(2)}");
            Console.WriteLine();

            Console.WriteLine("\n--- foreach: Keys ---");
            GibtListeAus(table.Keys);
            Console.WriteLine("\n--- foreach: Values ---");
            GibtListeAus(table.Values);
        }

        private static void GibtListeAus(IEnumerable liste)
        {
            foreach (var aktuellesElement in liste)
            {
                Console.WriteLine(aktuellesElement);
            }
        }
    }
}