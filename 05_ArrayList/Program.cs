using System;
using System.Collections;

namespace _05_ArrayList
{
    public class Program
    {
        public static void Main()
        {
            StarteArrayListDemo();
        }

        private static void StarteArrayListDemo()
        {
            ArrayList liste = new();
            //IList list = new ArrayList(); // Wenn man diese Zeile benutzt, funktionieren gewisse ArrayList-spezifische Methoden nicht mehr,
            // dafür kann man ArrayList durch eine andere Implementierung ersetzen

            liste.Add("Hello");
            liste.Add("World");

            int indexVomAusrufezeichen = liste.Add("!"); // Im Gegensatz zur Zeile oben, fangen wird hier den
                                                         // Rückgabewert der Add-Methode ab für die Verwendung
                                                         // unten
            int index = indexVomAusrufezeichen;
            object wert = liste[indexVomAusrufezeichen];

            Console.WriteLine("--- Wert ---");
            Console.WriteLine($"list[{index}] = {wert}");

            Console.WriteLine("\n--- Eigenschaften ---");
            Console.WriteLine($"Count: {liste.Count}");
            Console.WriteLine($"Capacity: {liste.Capacity}");

            Console.WriteLine("\n--- foreach ---");
            //list.Add(1);  // Wenn man hier einen int in die Liste einfügt, kommt es in der unteren
            // foreach-Schleife zu einer Exception:
            //
            // Unhandled Exception: System.InvalidCastException: Unable to cast object of type 'System.Int32'
            // to type 'System.String'.
            //
            // Das ist eine der Gefahren mit Collections, die mit objects arbeiten
            foreach (string aktuellesElement in liste)
            {
                Console.WriteLine(aktuellesElement);
            }

            Console.WriteLine("\n--- Index ---");
            Console.WriteLine($"{nameof(liste)}[0] = {liste[0]}");
            Console.WriteLine($"{nameof(liste)}[1] = {liste[1]}");

            Console.WriteLine("\n--- Methode ---");
            Console.WriteLine($"Contains(\"Hello\"): {liste.Contains("Hello")}");
        }
    }
}