using System.Diagnostics.CodeAnalysis;

namespace _23_Interfaces_IComparable
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        static void Main()
        {
            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    SortierBeispielMitIntArray_EinBereitsVordefinierterTyp();
                    break;
                case 2:
                    SortierBeispielMitMitarbeiterArray_EinSelbstgebauterTyp();
                    break;
            }
        }

        private static void SortierBeispielMitIntArray_EinBereitsVordefinierterTyp()
        {
            var zahlenliste = new int[] { 7, 5, 12, 1 };
            Array.Sort(zahlenliste);
            foreach (int i in zahlenliste)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }

        private static void SortierBeispielMitMitarbeiterArray_EinSelbstgebauterTyp()
        {
            Mitarbeiter[] mitarbeiterListe = {
                new Mitarbeiter { Name = "Hans", Lohn = 2 },
                new Mitarbeiter { Name = "Peter", Lohn = 1 },
                new Mitarbeiter { Name = "Simon", Lohn = 3 }
            };

            Console.WriteLine("--- Vor der Sortierung ---");
            GibMitarbeiterListeAus(mitarbeiterListe);

            Array.Sort(mitarbeiterListe);

            Console.WriteLine();
            Console.WriteLine("--- Nach der Sortierung ---");
            GibMitarbeiterListeAus(mitarbeiterListe);
        }

        private static void GibMitarbeiterListeAus(Mitarbeiter[] mitarbeiterListe)
        {
            foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
            {
                Console.WriteLine($"Name: {mitarbeiter.Name}, Lohn: {mitarbeiter.Lohn}");
            }
        }
    }
}