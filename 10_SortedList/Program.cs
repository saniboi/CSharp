using System;
using System.Collections;

namespace _10_SortedList
{
    internal class Program
    {
        public static void Main()
        {
            StarteSortedListDemo();
        }

        /// <summary>
        /// Das Beispiel ist aus der .NET-Dokumentation übernommen und angepasst (absichtlich Deutsch und Englisch gemischt)
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.sortedlist?view=net-6.0#examples
        /// </summary>
        private static void StarteSortedListDemo()
        {

            // Creates and initializes a new SortedList
            SortedList sortedList = new(); // SortedList klingt als handle es sich um eine List-Datenstruktur, es ist aber eine Dictionary-Datenstruktur.
                                           // "List" in "SortedList" ist ein unglücklich gewählter Klassenname.
                                           // "SortedDictonary" wäre ein klarerer Klassenname gewesen.

            // Die Inhalte werden in einer beliebigen dem Dictionary hinzugefügt, sie werden aber beim Einfügen direkt richtig einsortiert
            sortedList.Add("Third", "!");
            sortedList.Add("First", "Hello");
            sortedList.Add("Second", "World");

            // Displays the properties and values of the SortedList
            Console.WriteLine($"{nameof(sortedList)}");
            Console.WriteLine($"  Count:    {sortedList.Count}");
            Console.WriteLine($"  Capacity: {sortedList.Capacity}");
            Console.WriteLine("  Keys and Values:");
            PrintKeysAndValues(sortedList);
        }

        public static void PrintKeysAndValues(SortedList dictionary)
        {
            Console.WriteLine("\n--- PrintKeysAndValues(...): Der Inhalt ist alphabetisch nach dem Schlüssel sortiert ---");
            Console.WriteLine("\tKey\tValue");
            Console.WriteLine("\t-------------");
            foreach (DictionaryEntry dictionaryEntry in dictionary)
            {
                Console.WriteLine($"\t{dictionaryEntry.Key}\t{dictionaryEntry.Value}");
            }
        }
    }
}
