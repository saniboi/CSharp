using System;
using Spectre.Console;

namespace Konsole_FormatierungInDerKonsole
{
    public class Program
    {
        public static void Main()
        {
            // Möglichkeit 1: Mit Tabulator \t
            Console.WriteLine("\n--- Möglichkeit 1 ---");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello \t\t\t\tWorld!");
            Console.WriteLine("Hello \tWorld!");

            // Möglichkeit 2: Mit string.Format $"{meineVariable,Spaltenbreite}
            Console.WriteLine("\n--- Möglichkeit 2 ---");
            const int spaltenbreite = 30; // Zeichen
            Console.WriteLine($"Kartoffel: {1,spaltenbreite} kg");
            Console.WriteLine($"Rüebli:    {123,spaltenbreite} kg");
            Console.WriteLine($"Zucchetti: {34,spaltenbreite} kg");

            // Möglichkeit 3: LeftPad, RightPad, https://docs.microsoft.com/en-us/dotnet/standard/base-types/padding
            Console.WriteLine("\n--- Möglichkeit 3 ---");
            Console.WriteLine($"Kartoffel: {1.ToString().PadLeft(spaltenbreite, '.')} kg");
            Console.WriteLine($"Rüebli:    {123.ToString().PadLeft(spaltenbreite, '.')} kg");
            Console.WriteLine($"Zucchetti: {34.ToString().PadLeft(spaltenbreite, '.')} kg");

            // Möglichkeit 4: Mit einer externen Bibliothek wie Spectre.Console, https://spectreconsole.net/widgets/table
            // Create a table
            Console.WriteLine("\n--- Möglichkeit 4 ---");
            var table = new Table();

            // Add some columns
            table.AddColumn("Gericht");
            table.AddColumn("Zutate");
            var tableColumn = new TableColumn("Menge").Alignment(Justify.Right);
            table.AddColumn(tableColumn);
            table.AddColumn("Einheit");

            // Add some rows
            table.AddRow("Gericht1", "Kartoffel", "1", "kg");
            table.AddRow("", "Rüebli", "123", "kg");
            table.AddRow("", "Zucchetti", "34", "kg");

            // Render the table to the console
            AnsiConsole.Write(table);

        }
    }
}
