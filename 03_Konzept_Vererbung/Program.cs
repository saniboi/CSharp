namespace _03_Konzept_Vererbung
{
    public class Program
    {
        public static void Main()
        {
            var vater = new Elternklasse { Haarfarbe = "Braun" };
            var mutter = new Elternklasse { Haarfarbe = "Blond" };

            var tochter = new Kind { Haarfarbe = "Blond" };   // Die Eigenschaft wurde vom Elternteil geerbt;
                                                              // die Klasse Kind ist "leer"
            var sohn = new Kind { Haarfarbe = "Schwarz" };

            var enkelkind = new Enkelkind { Spitzname = "Pädu" };


            Console.WriteLine($"Vaters Haarfarbe: {vater.Haarfarbe}");
            Console.WriteLine($"Mutters Haarfarbe: {mutter.Haarfarbe}");
            Console.WriteLine($"Tochters Haarfarbe: {tochter.Haarfarbe}");              // Geerbte Eigenschaft (C#-Eigenschaft)
            Console.WriteLine($"Sohns Haarfarbe: {sohn.Haarfarbe}");                    // Geerbte Eigenschaft (C#-Eigenschaft)
            Console.WriteLine($"Tochters Gene: {tochter.GibEtwasAufDieKonsoleAus()}");  // Geerbtes Verhalten (C#-Methode)
            Console.WriteLine($"Enkelkinds Spitzname: {enkelkind.Spitzname}");          // Geerbtes Verhalten (C#-Methode)
        }

        public class Elternklasse
        {
            public string Haarfarbe { get; set; } = null!;

            public string GibEtwasAufDieKonsoleAus()
            {
                return "Vererbte Gensequenz des Elternteils";
            }
        }

        public class Kind : Elternklasse // Doppelpunkt ":" ist das Vererbungszeichen in C#; analog zu "Kind extends Elternklasse" in Java
                                         // "Kind" ist die Unterklasse, die erbende Klasse
                                         // "Elternklasse" ist die Oberklasse, die Basisklasse, die Mutterklasse, die Vaterklasse, die Elternklasse, die vererbende Klasse
        {
            // Nichts
        }

        public class Enkelkind : Kind
        {
            public string Spitzname { get; set; } = null!; // Zusätzliche spezialisierte Eigenschaft, welche weder Eltern noch Grosseltern haben
        }
    }
}