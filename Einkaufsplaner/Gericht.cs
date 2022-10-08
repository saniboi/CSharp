using System;
using System.Collections.Generic;

namespace Einkaufsplaner
{
    public class Gericht
    {
        public string Name { get; set; }
        public List<Zutat> ZutatenList = new List<Zutat>();

        public Gericht(string name)
        {
            this.Name = name;
        }

    public void ZutatenEinlesen()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Zutatname eingeben");
                var zutatname = Console.ReadLine();

                Console.WriteLine("");
                Console.WriteLine("Menge eingeben");


                var menge = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());


                Console.WriteLine("");
                Console.WriteLine("Einheit eingeben");
                var einheitenAuswahl = new List<string>
                {
                    "0. für kg",
                    "1. für g",
                    "2. für mg",
                    "3. für l",
                    "4. für dl",
                    "5. für cl",
                    "6. für ml",
                    "7. für EL",
                    "8. für TL",
                    "9. für Tasse",
                    "10. für Stk",
                    "11. für Zweiglein",
                    "12. für wenig",
                    "13. für Bund"
                };

                foreach (var einheitenAusgabe in einheitenAuswahl)
                {
                    Console.WriteLine(einheitenAusgabe);
                }

                var einheit = int.Parse(Console.ReadLine()?.ToLower() ?? throw new InvalidOperationException());

                ZutatenList.Add(new Zutat
                {
                    Zutatname = zutatname,
                    Menge = menge,
                    Einheit = (EnumEinheit) einheit
                });

                Console.WriteLine("Möchten Sie weitere Zutaten eingeben? ja oder nein");
                var eingabeAbbruch = Console.ReadLine();

                if (eingabeAbbruch == "nein")
                {
                    break;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name}" + $"{ZutatenList}";
        }
    }
}
