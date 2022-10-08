using System;
using System.Diagnostics.CodeAnalysis;

namespace Übung_2_4_Sieb_des_Eratosthenes
{
    public class Program
    {
        [SuppressMessage("ReSharper", "RedundantBoolCompare")]
        public static void Main()
        {
            // Konfiguration des Programms
            int obereGrenze = 1000;

            bool[] zahlen = new bool[obereGrenze]; // Alle Elemente werden mit false initialisiert

            // Initialisierung mit true
            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] = true;
            }

            // 0 und 1 sind per Definition keine Primzahlen, also die als false markieren
            zahlen[0] = false;
            zahlen[1] = false;

            // Von 2 bis zur Obergrenze hochzählen (Optimierungsmöglichkeit: eigentlich reicht es, wenn man bis zur Hälfte gehen würde)
            for (int i = 2; i <= zahlen.Length; i++)
            {
                // Die Vielfachen der aktuellen Zahl nehmen und als false markieren.
                // Die aktuelle Zahl selber nicht, darum i*2, denn die könnte eine Primzahl sein, wenn sie bisher nicht als false markiert wurde.
                for (int j = i * 2; j < zahlen.Length; j = j + i)
                {
                    Console.WriteLine($"Diese Zahl ist keine Primzahl: i = {i}, j = {j}");
                    zahlen[j] = false;
                }
            }

            // Primzahlen ausgeben
            Console.WriteLine();
            Console.WriteLine($"Die Primzahlen bis {obereGrenze} sind: ");
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] == true)
                {
                    Console.Write($"{i} ");
                }
            }

            Console.WriteLine();
        }
    }
}