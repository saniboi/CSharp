using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _05_LINQ_to_CSV
{
    public class Program
    {
        private string delimiter = ",;";

        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            string pathToCsvFile = @"InputData\Books.csv";
            string[] lines = File.ReadAllLines(pathToCsvFile);

            int beispiel = 3;
            Program program = new();

            switch (beispiel)
            {
                case 1:
                    program.LinqToCsvBeispiel(lines);
                    break;
                case 2:
                    program.LinqToCsvBeispiel_GleichesBeispielWieObenAberMitKommentarenFürJedeLinqZeile(lines);
                    break;
                case 3:
                    program.LinqToCsvBeispiel_MitAllenZwischenergebnissen(lines);
                    break;
            }
        }

        private void LinqToCsvBeispiel(string[] lines)
        {
            // ToList() konvertiert die string[] in eine List<string> um, falls man das möchte; hier nicht notwending,
            // weil ein Array auch ein IEnumerable ist.
            //List<string> lines = File.ReadAllLines(pathToCsvFile).ToList<string>();
            
            // Vorteil von LINQ: die ganzen komplizierten Filter- und Parsing-Schritte, könnten wir
            // deklarativ vorgeben, statt viele Schlaufen programmieren zu müssen

            // Code ohne Erklärungen zwischen den Zeilen
            var jackBauersCheapBooks =
                lines
                    .Where(line => !string.IsNullOrEmpty(line))
                    .Select(line => line.Split(delimiter.ToCharArray()))
                    .Where(lineElements => lineElements[1].Trim().Equals("Jack Bauer", StringComparison.InvariantCultureIgnoreCase))
                    .Where(lineElements => double.Parse(lineElements[4], NumberStyles.Any) <= 30)
                    .Select(oneLineElement => string.Join(" - ", oneLineElement))
                    .ToList<string>();

            Console.WriteLine("--- Komplette Originalliste ---");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\n--- Gefilterte Liste (Author Jack Bauer, Preis <= 30) ---");
            foreach (var line in jackBauersCheapBooks)
            {
                Console.WriteLine(line);
            }
        }

        private void LinqToCsvBeispiel_GleichesBeispielWieObenAberMitKommentarenFürJedeLinqZeile(string[] lines)
        {
            // ToList() konvertiert die string[] in eine List<string> um, falls man das möchte; hier nicht notwending,
            // weil ein Array auch ein IEnumerable ist.
            //List<string> lines = File.ReadAllLines(pathToCsvFile).ToList<string>();


            // Code ohne Erklärungen zwischen den Zeilen
            //var jackBauersCheapBooks =
            //    lines
            //        .Where(line => !string.IsNullOrEmpty(line))
            //        .Select(line => line.Split(delimiter.ToCharArray()))
            //        .Where(lineElements => lineElements[1].Trim().Equals("Jack Bauer", StringComparison.InvariantCultureIgnoreCase))
            //        .Where(lineElements => double.Parse(lineElements[4], NumberStyles.Any) <= 30)
            //        .Select(oneLineElement => string.Join(" - ", oneLineElement))
            //        .ToList<string>();

            // Code mit Erklärungen zwischen den Zeilen
            var jackBauersCheapBooks = 
                lines

                    // Leere Zeilen ignorieren.
                    .Where(line => !string.IsNullOrEmpty(line))

                    // Zeile zerlegen mit Trennzeichen aus "delimiter".
                    // StringSplitOptions.RemoveEmptyEntries ist hier keine gute Idee, weil 
                    // die Applikation abstürzen wird, wenn fehlende Werte entfernt werden
                    // und die Reihenfolge der Array-Element sich dadurch ändert.
                    .Select(line => line.Split(delimiter.ToCharArray() /*, StringSplitOptions.RemoveEmptyEntries*/))

                    // Spalte "Author" (Feld 1) vergleichen; alle Bücher von Jack Bauer selektieren.
                    // Trim(), um etwaige Leerzeichen in der CSV-Datei zu bereinigen.
                    // InvariantCultureIgnoreCase, um auch kleingeschriebene "jack bauer" zu selektieren.
                    .Where(lineElements => lineElements[1].Trim().Equals("Jack Bauer", StringComparison.InvariantCultureIgnoreCase))

                    // Spalte "Price" (Feld 4) vergleichen; alle Zeilen mit Preis <= 30 selektieren
                    // NumberStyles.Any, um die Parse-Exception zu verhindern, die ausgelöst werden kann, wenn
                    // die Windows-Spracheinstellung ein Komma als Dezimaltrennzeichen eingestellt hat, statt
                    // einem Punkt
                    //
                    // Praxisproblem: wenn der Benutzer unter Windows die Sprache "German (Germany)" gesetzt hat,
                    // wird die nächste Ziele keine Resultate liefern. Der Code kann wie folgt rebuster gemacht werden:
                    // .Where(linienElemente => decimal.Parse(linienElemente[price], NumberStyles.Currency, CultureInfo.InvariantCulture) <= maxPreis);
                    .Where(lineElements => double.Parse(lineElements[4], NumberStyles.Any) <= 30)

                    // Zerlegte Felder wieder zusammenfügen mit Join.
                    .Select(oneLineElement => string.Join(" - ", oneLineElement));

            Console.WriteLine("--- Komplette Originalliste ---");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\n--- Gefilterte Liste (Author Jack Bauer, Preis <= 30) ---");
            foreach (var line in jackBauersCheapBooks)
            {
                Console.WriteLine(line);
            }
        }

        private void LinqToCsvBeispiel_MitAllenZwischenergebnissen(string[] lines)
        {
            #region 0: Originalliste
            Console.WriteLine("--- Originalliste ---");
            foreach (string jackBauersCheapBook in lines)
            {
                Console.WriteLine(jackBauersCheapBook);
            }
            #endregion

            #region 1: IEnumerable<string>   ← .Where(line => !string.IsNullOrEmpty(line));
            IEnumerable<string> jackBauersCheapBooks =
                lines
                    .Where(line => !string.IsNullOrEmpty(line));

            Console.WriteLine("\n.Where(line => !string.IsNullOrEmpty(line))");
            foreach (string jackBauersCheapBook in jackBauersCheapBooks)
            {
                Console.WriteLine(jackBauersCheapBook);
            }
            #endregion

            #region 2: IEnumerable<string[]> ← .Select(line => line.Split(delimiter.ToCharArray()));
            IEnumerable<string[]> jackBauersCheapBooks2 =
                lines
                    .Where(line => !string.IsNullOrEmpty(line))
                    .Select(line => line.Split(delimiter.ToCharArray()));

            Console.WriteLine("\n.Select(line => line.Split(delimiter.ToCharArray()));");
            foreach (string[] jackBauersCheapBook in jackBauersCheapBooks2)
            {
                Console.Write("[");
                Console.Write(string.Join("][", jackBauersCheapBook));
                Console.WriteLine("]");
            }
            #endregion

            #region 3: IEnumerable<string[]> ← .Where(lineElements => lineElements[1].Trim().Equals("Jack Bauer", StringComparison.InvariantCultureIgnoreCase));
            IEnumerable<string[]> jackBauersCheapBooks3 =
                lines
                    .Where(line => !string.IsNullOrEmpty(line))
                    .Select(line => line.Split(delimiter.ToCharArray()))
                    .Where(lineElements =>
                        lineElements[1].Trim().Equals("Jack Bauer", StringComparison.InvariantCultureIgnoreCase));

            Console.WriteLine("\nWhere(lineElements => lineElements[1].Trim().Equals(\"Jack Bauer\", StringComparison.InvariantCultureIgnoreCase))");
            foreach (string[] jackBauersCheapBook in jackBauersCheapBooks3)
            {
                Console.Write("[");
                Console.Write(string.Join("][", jackBauersCheapBook));
                Console.WriteLine("]");
            }
            #endregion

            #region 4: IEnumerable<string[]> ← .Where(lineElements => double.Parse(lineElements[4], NumberStyles.Any) <= 30);
            IEnumerable<string[]> jackBauersCheapBooks4 =
                lines
                    .Where(line => !string.IsNullOrEmpty(line))
                    .Select(line => line.Split(delimiter.ToCharArray()))
                    .Where(lineElements =>
                        lineElements[1].Trim().Equals("Jack Bauer", StringComparison.InvariantCultureIgnoreCase))
                    .Where(lineElements => double.Parse(lineElements[4], NumberStyles.Any) <= 30);
            Console.WriteLine("\n.Where(lineElements => double.Parse(lineElements[4], NumberStyles.Any) <= 30)");
            foreach (string[] jackBauersCheapBook in jackBauersCheapBooks4)
            {
                Console.Write("[");
                Console.Write(string.Join("][", jackBauersCheapBook));
                Console.WriteLine("]");
            }
            #endregion

            #region 5: IEnumerable<string>   ← .Select(oneLineElement => string.Join(" - ", oneLineElement));
            IEnumerable<string> jackBauersCheapBooks5 =
                lines
                    .Where(line => !string.IsNullOrEmpty(line))
                    .Select(line => line.Split(delimiter.ToCharArray()))
                    .Where(lineElements =>
                        lineElements[1].Trim().Equals("Jack Bauer", StringComparison.InvariantCultureIgnoreCase))
                    .Where(lineElements => double.Parse(lineElements[4], NumberStyles.Any) <= 30)
                    .Select(oneLineElement => string.Join(" - ", oneLineElement));
            Console.WriteLine("\n.Select(oneLineElement => string.Join(\" - \", oneLineElement))");
            foreach (string jackBauersCheapBook in jackBauersCheapBooks5)
            {
                Console.WriteLine(jackBauersCheapBook);
            }
            #endregion
        }
    }
}