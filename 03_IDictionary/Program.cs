using System;
using System.Collections;

namespace _03_IDictionary
{
    /// <summary>
    /// Implementierungen von IDictionary sind https://docs.microsoft.com/en-us/dotnet/api/system.collections.idictionary?view=net-6.0
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            StarteDictionaryDemo();
        }

        private static void StarteDictionaryDemo()
        {
            IDictionary dictionary = new Hashtable(); // Gegen das Interface programmieren, sofern man keine Hashtable-spezifischen Funktionalitäten braucht

            dictionary[1] = "One";
            dictionary["irgendwas"] = "Two";
            dictionary[13] = "Thirteen";
            dictionary[13] = "Hello World"; // Schlüssel sind eindeutig, d.h. obiges [13] wird überschrieben; Werte sind nicht eindeutig

            Console.WriteLine("--- Properties ---");
            Console.WriteLine($"IsFixedSize: {dictionary.IsFixedSize}"); // Ja nach konkreter Implementierung ist es true oder false
            Console.WriteLine($"IsReadOnly: {dictionary.IsReadOnly}");   // Ja nach konkreter Implementierung ist es true oder false

            Console.WriteLine("\n--- Keys ---");
            ICollection keys = dictionary.Keys;
            foreach (object key in keys)
            {
                Console.WriteLine($"Key: {key}");
            }

            Console.WriteLine("\n--- Values ---");
            ICollection values = dictionary.Values;
            foreach (object value in values)
            {
                Console.WriteLine($"Value: {value}");
            }

            dictionary.Add("test", 123); // Sowohl Schlüssel als auch Wert sind hier object-Instanzen
            dictionary.Remove("test");
            Console.WriteLine("\n--- Contains ---");
            Console.WriteLine($"Contains(13): {dictionary.Contains(13)}");

            Console.WriteLine("\n--- DictionaryEntry ---");
            foreach (DictionaryEntry entry in dictionary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.WriteLine("\n--- Clear() ---");
            dictionary.Clear();
            Console.WriteLine("--- Begin of cleared ---");
            foreach (DictionaryEntry entry in dictionary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
            Console.WriteLine("   ...leer...");
            Console.WriteLine("--- End of cleared ---");
        }
    }
}