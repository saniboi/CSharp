using System.Diagnostics.CodeAnalysis;
#pragma warning disable 168

namespace _10_Datenfelder
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    EindimensionalesDatenfeld();
                    break;
                case 2:
                    ZweiUndMehrdimensionalesDatenfeld();
                    break;
                case 3:
                    MehrdimenisonalesDatenfeldBeispielAusDenFolien();
                    break;
                case 4:
                    VerzweigteDatenfelder();
                    break;
            }
        }

        private static void EindimensionalesDatenfeld()
        {
            // Eindimensionales Datenfeld
            // Dokumentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/

            int[] oneDimensionalArray; // Das "string[] args" aus "public static void Main(string[] args) {...}" ist auch ein Datenfeld

            int[] oneDimensionalArray2 = new int[3]; // Alle Elemente werden mit 0 initialisiert
            //              3 Spalten
            //            -------------
            //   1 Zeile  | . | . | . | 
            //            -------------
            oneDimensionalArray2[/*Index*/ 0] = 17;
            oneDimensionalArray2[/*Index*/ 1] = 22;
            oneDimensionalArray2[/*Index*/ 2] = 35;

            int[] oneDimensionalArray3 = new int[3] { 17, 22, 35 }; // Ursprüngliche, vollständige Schreibweise mit Wertezuweisung
                                                                    // In der Initialisierungsschreibeweise kann das 3 weggelassen werden, weil die Dimension automatisch abgeleitet werde kann
            int[] oneDimensionalArray4 = new int[] { 17, 22, 35 };  // In der Initialisierungsschreibeweise kann auch "new int[]" weggelassen werden, weil auch der Typ automatisch abgeleitet werden kann
            int[] oneDimensionalArray5 = { 17, 22, 35 };            // In der Initialisierungsschreibeweise reichen die Werte

            Console.WriteLine("--- Eindimensionales Datenfeld ausgeben ---");
            foreach (int aktuellesElement in oneDimensionalArray5)      // Jedes Element aus oneDimensionalArray5 wird eins nach dem anderen in die Variablen "element" geschrieben
            {
                Console.WriteLine($"{nameof(aktuellesElement)}: {aktuellesElement}");
            }
            Console.WriteLine();

            Console.WriteLine("--- Eindimensionales Datenfeld alternativ mit for-Schleife durchlaufen, falls man den Index benötigt ---");
            for (int i = 0; i < oneDimensionalArray5.Length; i++)        // oneDimensionalArray5.Length = 3
                                                                         // Beachte: die Schleifenindizes sind 0 bis und mit Lenght-1 (3-1=2)
                                                                         // Test: Schleife bis "i <=" laufen lassen
                                                                         // Testergebnis: System.IndexOutOfRangeException: Index was outside the bounds of the array.
            {
                Console.WriteLine($"oneDimensionalArray5[{i}] = {oneDimensionalArray5[i]}");
            }
            Console.WriteLine();
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void ZweiUndMehrdimensionalesDatenfeld()
        {
            double[,] twoDimensionalArray;                                 // Zweidimensionales Datenfeld
            double[,,] threeDimensionalArray = new double[3, 4, 5];        // Kann man sich als Quader vorstellen: https://de.wikipedia.org/wiki/Quader
            double[,,,] fourDimensionalArray = new double[30, 2, 40, 30];  // Lässt sich nicht mehr geometrisch vorstellen, weil es mehr als 3 Dimensionen sind

            double[,] twoDimensionalArray2 = new double[2, 2];             // Mit Schlüsselwort "new" instanziieren
            twoDimensionalArray2[0 /*Zeile*/, 0 /*Spalte*/] = 1.4;         // Variante wie man jede Zelle einzeln adressiert und setzt
            twoDimensionalArray2[0 /*Zeile*/, 1 /*Spalte*/] = 2.4;
            twoDimensionalArray2[1 /*Zeile*/, 0 /*Spalte*/] = 3.4;
            twoDimensionalArray2[1 /*Zeile*/, 1 /*Spalte*/] = 4.4;

            // twoDimensionalArray2 sieht tabellarisch so aus:
            //
            //          Spalte 0    Spalte 1         
            //          ----------------------
            // Zeile 0: |   1.4   |    2.4   |
            //          ----------------------
            // Zeile 1: |   3.4   |    4.4   |
            //          ----------------------

            double[,] twoDimensionalArray3 = new double[2 /*Zeilen*/, 3 /*Spalten*/] { { 1.4, 2.4, 3.4 }, { 4.4, 5.4, 6.4 } }; // Das Datenfeld muss nicht quadratisch sein
            double[,] twoDimensionalArray4 = new double[2, 3] // Werte untereinander schreiben, damit der Code leserlicher wird
            {
                    { 1.4, 2.4, 3.4 },
                    { 4.4, 5.4, 6.4 }
            };
            double[,] twoDimensionalArray5 = { { 1.4, 2.4 }, { 3.4, 4.4 } }; // Das "new int[2, 2]" kann weggelassen werden, weil es automatisch abgeleitet werden kann



            Console.WriteLine("--- Mehrdimensionales Datenfeld zeilenweise ausgeben; jedes Element in der Tabelle ---");
            foreach (double element in twoDimensionalArray5)
            {
                Console.WriteLine($"{nameof(element)}: {element}");
            }
            Console.WriteLine();

            Console.WriteLine("--- Alternative mit zwei geschachtelten for-Schleifen, falls man die Indizes benötigt ---");
            for (int i = 0; i < twoDimensionalArray3.GetLength(0 /*Nullte Rang ist die Anzahl Zeilen = 2*/); i++)
            {
                for (int j = 0; j < twoDimensionalArray3.GetLength(1 /*Erste Rang ist die Anzahl Spalten = 3*/); j++)
                {
                    Console.WriteLine("twoDimensionalArray3[{0},{1}] = {2}", i, j, twoDimensionalArray3[i, j]);
                }
            }
            Console.WriteLine();
        }

        private static void MehrdimenisonalesDatenfeldBeispielAusDenFolien()
        {
            Console.WriteLine(@"--- ""GetDimension""-BeispielAusDenFolien ---");

            int[] arr1Dim = new int[5];
            //                   5 Spalten
            //              ---------------------
            //   1 Zeile    | . | . | . | . | . | 
            //              ---------------------
            Console.WriteLine($"arr1Dim.Length = {arr1Dim.Length}");                        // Ausgabe: 5
            Console.WriteLine($"arr1Dim.GetLength(0) = {arr1Dim.GetLength(0)}");     // Ausgabe: 5
            //Console.WriteLine(arr1Dim.GetLength(1));           // IndexOutOfRangeException, weil es keine zweite (= Index 1) Dimension gibt


            //                        /---- 3 ist die nullte Dimension: arr2Dim.GetLength(0)
            //                       |
            //                       |  /-- 4 ist die erste Dimension: arr2Dim.GetLength(1)
            //                       |  |
            //                       ↓  ↓
            int[,] arr2Dim = new int[3, 4];
            //                4 Spalten
            //             -----------------
            //             | . | . | . | . |
            //             -----------------
            //  3 Zeilen   | . | . | . | . |
            //             -----------------
            //             | . | . | . | . |
            //             -----------------
            Console.WriteLine($"arr2Dim.GetLength(0) = {arr2Dim.GetLength(0)}"); // Ausgabe: 3
            Console.WriteLine($"arr2Dim.GetLength(1) = {arr2Dim.GetLength(1)}"); // Ausgabe: 4
            Console.WriteLine($"arr2Dim.Length       = {arr2Dim.Length}");               // Ausgabe: 12 (= 3 x 4)
        }

        private static void VerzweigteDatenfelder()
        {
            // Verzweigte Datenfelder (jagged arrays)
            // Verzweigte Datenfelder sind Arrays von Arrays
            // Dokumentation: https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/arrays/jagged-arrays

            int[][] jaggedArray = new int[3][]; // Das ist ein eindimensionales Datenfeld, dessen Elemente wiederum eindimensionale Datenfelder sind
                                                // Beachte: vorher war es int[,] mit Komma, jetzt ist es int[][]
                                                // Das sieht man etwas klarer im folgenden bei der Initialisierung der einzelnen Elemente
            jaggedArray[0] = new int[3];
            jaggedArray[1] = new int[5];
            jaggedArray[2] = new int[4];

            //              /---- Ein Array mit 3 Einträgen mit Index 0 bis Index 2
            //              |
            //              |  /-- Jedes Element ist selber wieder um ein Array. Und jede kann eine andere Länge haben.
            //              |  |
            //              ↓  ↓
            //          int[]
            //             [0] [0, 1, 2]
            //             [1] [0, 1, 2, 3, 4] 
            //             [2] [0, 1, 2, 4]
            //
            //                3 bis 5 Spalten
            //             -------------
            //             | . | . | . |
            //             ---------------------
            //  3 Zeilen   | . | . | . | . | . |
            //             ---------------------
            //             | . | . | . | . |
            //             -----------------

            jaggedArray[0][0] = 5; jaggedArray[0][1] = 4; jaggedArray[0][2] = 3;
            jaggedArray[1] = new int[] { 2, 1, 0, 7, 6 };
            jaggedArray[2] = new int[] { 9, 2, 0, 5 };

            Console.WriteLine("--- Verzweigtes Datenfeld ausgeben ---");
            foreach (int[] aktuelleZeile in jaggedArray)
            {
                Console.WriteLine("-- aktuelleZeile --");
                foreach (int aktuellesElement in aktuelleZeile)
                {
                    Console.WriteLine($"{nameof(aktuellesElement)}: {aktuellesElement}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("--- Verzweigtes Datenfeld mit for-Schleife ausgeben ---");
            for (int x = 0; x < jaggedArray.Length; x++)
            {
                Console.WriteLine($"Element[{x}]");
                for (int y = 0; y < jaggedArray[x].Length; y++) // Bei verzeigten Datenfeldern wird einfach Length verwendet, nicht GetDimension wie bei mehrdimensionalen Arrays
                {
                    Console.WriteLine($"Element[x={x}][y={y}] = {jaggedArray[x][y]}");
                }
            }
        }
    }
}