using System;

namespace Übung_4_1_Exceptions
{
    public class Person : IComparable
    {
        // Teilaufgabe 1)
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Stadt { get; set; }

        // Teilaufgabe 2)
        public int CompareTo(object obj)
        {
            if (!(obj is Person))
            {
                Console.WriteLine("Es ist _nicht_ möglich die beiden Objekte zu vergleichen, weil es unterschiedliche Typen sind.");
                throw new ArgumentException($"obj ist nicht vom Type Person, sondern {obj.GetType()}");
            }
            Console.WriteLine("Es ist möglich die beiden Objekte zu vergleichen, weil es gleiche Typen sind.");
            // Analog zur Üb. 3.4 IComparable
            var dieAndereStadt = (obj as Person).Stadt;
            return String.Compare(Stadt, dieAndereStadt, StringComparison.InvariantCulture); // Wir können einfach die
                                                                                                     // existierende CompareTo-Methode von
                                                                                                     // string wiederverwenden.
        }

        public override string ToString()
        {
            return $"Person: {nameof(Vorname)} = {Vorname}, {nameof(Nachname)} = {Nachname}, {nameof(Stadt)} = {Stadt}";
        }
    }
}