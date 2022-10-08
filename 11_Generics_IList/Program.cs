using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis; // List<T> kommt aus diesem Namensraum

namespace _10_Generics_IList
{
    /// <summary>
    /// List<T>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public class Program
    {
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        public static void Main()
        {
            var list = new List<string>(); // List<T>: Das T (für type) ist ein Platzhalter für einen beliebigen Typen.
            //var list = new List<int>();
            //var list = new List<Person>();

            //var dictionary = new Dictionary<string, Person>();


            list.Add("string");
            //list.Add(1); // Nutzen: Das geht jetzt nicht mehr, weil wir die Liste typisiert haben, so dass sie nur noch Strings akzeptiert

            // Via Indexer auf den Wert zugreifen
            list[0] = "string2 - neuer Wert";

            list.Insert(1, "string3");

            Console.WriteLine("--- foreach-Schleife ---");
            foreach (string item in list) // Nutzen: Hier ist es auch typisiert. Wir erhalten Strings zurück, keine Objects wie bisher
            {
                Console.WriteLine(item);
            }
        }
    }
}