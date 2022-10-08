using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Spectre.Console;

namespace Einkaufsplaner
{
    class Kommando
    {
        public int Wert = 2;
        public string Eingabeuserfuehrung;
        private string EingabeUserMenuefuehrung => Eingabeuserfuehrung;
        public List<Gericht> GerichtList = new List<Gericht>();
        private string gerichtNameEingabe;

        public void Start()
        {
            Console.WriteLine("Hi, hier kannst du deinen Einkauf planen");
            Console.WriteLine("________________________________________");
            Console.WriteLine("");
        }

        public void MenueFuehrung()
        {
            Console.WriteLine("Bitte waehle eines von den folgenden Funktionen aus");
            Console.WriteLine("indem du einfach die Zahl, welcher vor dem Funktion steht, eingibst");
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine("");
            
            var menuefuehrung = new List<string>
            {
                "1. Gericht erfassen",
                "2. Gericht anzeigen",
                "3. Gericht mutieren",
                "4. Gericht loeschen",
                "5. Einkaufsliste anzeigen",
                "6. Programm beenden"
            };

            foreach (var menuefuehrungAusgabe in menuefuehrung)
            {
                Console.WriteLine(menuefuehrungAusgabe);
            }

            Console.WriteLine("");

            Eingabeuserfuehrung = Console.ReadLine();

            while (!int.TryParse(Eingabeuserfuehrung, out Wert))
            {
                Console.WriteLine("Falsche Eingabe, bitte gebe eine Zahl ein!");
                Eingabeuserfuehrung = Console.ReadLine();
            }
            

            switch (EingabeUserMenuefuehrung)
            {
                case "1":
                    Console.WriteLine("");
                    Console.WriteLine("Du möchtest ein neues Gericht erfassen");
                    Console.WriteLine("");
                    GerichtErfassen();
                    break;
                case "2":
                    Console.WriteLine("");
                    Console.WriteLine("Du möchtest die Gerichte anzeigen");
                    Console.WriteLine("");
                    GerichtAnzeigen();
                    break;
                case "3":
                    Console.WriteLine("");
                    Console.WriteLine("Du möchtest den Namen eines Gerichtes ändern");
                    Console.WriteLine("");
                    GerichtMutieren();
                    break;
                case "4":
                    Console.WriteLine("");
                    Console.WriteLine("Du möchtest einen Gericht löschen");
                    Console.WriteLine("");
                    GerichtLoeschen();
                    break;
                case "5":
                    Console.WriteLine("");
                    Console.WriteLine("Du möchtest deine Einkaufsliste anzeigen");
                    Console.WriteLine("");
                    EinkaufslisteAnzeigen();
                    break;
                case "6":
                    ProgrammBeenden();
                    break;
            }
        }

        public void GerichtErfassen()
        {
            Console.WriteLine("");
            Console.WriteLine("Gebe hier den Namen des Gerichtes ein");
            gerichtNameEingabe = Console.ReadLine();
            Gericht gericht = new Gericht(gerichtNameEingabe);
            gericht.ZutatenEinlesen();
            GerichtList.Add(gericht);
        }

        public void GerichtAnzeigen()
        {
            foreach (Gericht gericht in GerichtList)
            {
                Table tabelle = new Table();
                tabelle.BorderColor(Color.Cyan3);
                tabelle.AddColumn("Zutat");
                var tableColumn = new TableColumn("Menge").Alignment(Justify.Right);
                tabelle.AddColumn(tableColumn);
                tabelle.AddColumn("Einheit");
                tabelle.Title(gericht.Name);

                foreach (var zutat in gericht.ZutatenList)
                {
                    tabelle.AddRow(zutat.Zutatname, zutat.Menge.ToString(CultureInfo.InvariantCulture), zutat.Einheit.ToString());
                }

                AnsiConsole.Write(tabelle);
            }
        }


        public void GerichtMutieren()
        {
            foreach (Gericht gericht in GerichtList)
            {
                Table tabelle = new Table();
                tabelle.BorderColor(Color.Cyan3);
                tabelle.AddColumn("Gerichtname");
                tabelle.AddColumn("Index");
                tabelle.AddRow(gericht.Name, GerichtList.IndexOf(gericht).ToString());
                AnsiConsole.Write(tabelle);
            }
            Console.WriteLine("gebe die Indexnummer vom Gericht ein welche du den Namen ändern möchtest");
            var indexZuMutieren = Int32.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("gebe nun den Neuen Namen ein");
            string mutierterName = Console.ReadLine();
            GerichtList[indexZuMutieren].Name = mutierterName;
        }

        public void GerichtLoeschen()
        {
            foreach (Gericht gericht in GerichtList)
            {
                Table tabelle = new Table();
                tabelle.BorderColor(Color.Cyan3);
                tabelle.AddColumn("Gerichtname");
                tabelle.AddColumn("Index");
                tabelle.AddRow(gericht.Name, GerichtList.IndexOf(gericht).ToString());

                AnsiConsole.Write(tabelle);
            }
            Console.WriteLine("gebe die Indexnummer vom Gericht ein welche du löschen möchtest");
            var indexZuLoeschen = Int32.Parse(Console.ReadLine() ?? string.Empty);
            GerichtList.RemoveAt(indexZuLoeschen);
        }

        public void EinkaufslisteAnzeigen()
        {
            Table tabelle = new Table();
            tabelle.BorderColor(Color.Blue);
            tabelle.AddColumn("Zutat");
            var tableColumn = new TableColumn("Menge").Alignment(Justify.Right);
            tabelle.AddColumn(tableColumn);
            tabelle.AddColumn("Einheit");
            tabelle.Title("Einkaufsliste");

            foreach (Gericht gericht in GerichtList)
            {
                foreach (var zutat in gericht.ZutatenList)
                {
                    tabelle.AddRow(zutat.Zutatname, zutat.Menge.ToString(CultureInfo.InvariantCulture),
                    zutat.Einheit.ToString());
                }
            }
            AnsiConsole.Write(tabelle);
        }

        public void ProgrammBeenden()
        {
            Environment.Exit(0);
        }

        public void DefaultWerte()
        {
            Gericht gericht1 = new Gericht("Spaghetti Bolognese");
            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Zwiebel",
                Menge = 1,
                Einheit = EnumEinheit.Stk
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Koblauchzehen",
                Menge = 2,
                Einheit = EnumEinheit.Stk
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Rüebli",
                Menge = 50,
                Einheit = EnumEinheit.g
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Sellerie",
                Menge = 50,
                Einheit = EnumEinheit.g
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Olivenöl",
                Menge = 2,
                Einheit = EnumEinheit.EL
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Hackfleisch",
                Menge = 200,
                Einheit = EnumEinheit.g
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Tomatenpüree",
                Menge = 3,
                Einheit = EnumEinheit.EL
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Rotwein",
                Menge = 1,
                Einheit = EnumEinheit.dl
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Tomaten",
                Menge = 600,
                Einheit = EnumEinheit.g
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Rosmarin",
                Menge = 1,
                Einheit = EnumEinheit.Zweiglein
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "italienische Kräutermischung",
                Menge = 1,
                Einheit = EnumEinheit.TL
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Salz",
                Menge = 1.5,
                Einheit = EnumEinheit.TL
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Pfeffer",
                Menge = 1,
                Einheit = EnumEinheit.wenig
            });

            gericht1.ZutatenList.Add(new Zutat
            {
                Zutatname = "Zucker",
                Menge = 1,
                Einheit = EnumEinheit.TL
            });

            GerichtList.Add(gericht1);

            Gericht gericht2 = new Gericht("HörnliSalat");
            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "Teigwaren",
                Menge = 150,
                Einheit = EnumEinheit.g
            });

            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "grobkörniger Senf",
                Menge = 2,
                Einheit = EnumEinheit.EL
            });

            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "Weissweinessig",
                Menge = 5,
                Einheit = EnumEinheit.EL
            });

            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "Rapsöl",
                Menge = 3,
                Einheit = EnumEinheit.EL
            });

            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "Gemüsebouillon",
                Menge = 0.5,
                Einheit = EnumEinheit.dl
            });

            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "Gurke",
                Menge = 1,
                Einheit = EnumEinheit.Stk
            });

            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "Feta",
                Menge = 180,
                Einheit = EnumEinheit.g
            });

            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "Radiesli",
                Menge = 1,
                Einheit = EnumEinheit.Bund
            });

            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "Rucola",
                Menge = 50,
                Einheit = EnumEinheit.g
            });

            gericht2.ZutatenList.Add(new Zutat
            {
                Zutatname = "Schnittlauch",
                Menge = 3,
                Einheit = EnumEinheit.EL
            });

            GerichtList.Add(gericht2);

            Gericht gericht3 = new Gericht("Selleriesalat mit Poulet");
            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "scharfer Senf",
                Menge = 1,
                Einheit = EnumEinheit.TL
            });
            
            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "Zitronensaft",
                Menge = 2,
                Einheit = EnumEinheit.EL
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "Blanc battu",
                Menge = 150,
                Einheit = EnumEinheit.g
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "Salz",
                Menge = 0.25,
                Einheit = EnumEinheit.TL
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "Sellerie",
                Menge = 250,
                Einheit = EnumEinheit.g
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "Stangensellerie",
                Menge = 200,
                Einheit = EnumEinheit.g
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "geschnetzeltes Pouletfleisch",
                Menge = 300,
                Einheit = EnumEinheit.g
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "öl",
                Menge = 1,
                Einheit = EnumEinheit.wenig
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "Salz",
                Menge = 0.25,
                Einheit = EnumEinheit.TL
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "Apfel",
                Menge = 1,
                Einheit = EnumEinheit.Stk
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "Bratbutter",
                Menge = 1,
                Einheit = EnumEinheit.wenig
            });

            gericht3.ZutatenList.Add(new Zutat
            {
                Zutatname = "Apfelwein",
                Menge = 1,
                Einheit = EnumEinheit.dl
            });

            GerichtList.Add(gericht3);
        }
    }
}
