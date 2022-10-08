using System;
using System.Collections;

namespace _04_IList
{
    /// <summary>
    /// Beispiel-Code zu allen Methoden findet man unter https://docs.microsoft.com/en-us/dotnet/api/system.collections.arraylist?view=net-6.0#methods
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            StarteListDemo();
        }

        private static void StarteListDemo()
        {
            IList liste = new ArrayList();    // Gegen das Interface implementieren, sofern man keine ArrayListe-spezifischen Funktionalitäten braucht
            liste.Add("string");
            liste.Add(1);                     // int
            object objekt = new object();
            liste.Add(objekt);                // object
            liste.Add(DateTime.UtcNow);       // DateTime

            Console.WriteLine("\n--- foreach ---");
            int zähler = 0;
            foreach (object aktuellesElement in liste)
            {
                Console.WriteLine($"{nameof(aktuellesElement)}[{zähler}] = {aktuellesElement}");
                zähler++;
            }

            // Via Indexer auf Item zugreifen
            Console.WriteLine();
            liste[0] = "string2";
            Console.WriteLine($"{nameof(liste)}[1]: {liste[1]}");
            Console.WriteLine($"{nameof(liste)}.IndexOf(o): {liste.IndexOf(objekt)}");

            liste.Insert(1, "insert");
            liste.Remove(objekt);
            liste.RemoveAt(3);

            Console.WriteLine("\n--- foreach ---");
            zähler = 0;
            foreach (object aktuellesElement in liste)
            {
                Console.WriteLine($"{nameof(aktuellesElement)}[{zähler}] = {aktuellesElement}");
                zähler++;
            }
        }
    }
}