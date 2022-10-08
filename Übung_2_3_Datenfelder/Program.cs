using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Übung_2_3_Datenfelder
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 3;

            switch (beispiel)
            {
                case 1:
                    RunVersion_1_0();
                    break;
                case 2:
                    RunVersion_2_0();
                    break;
                case 3:
                    RunVersion_3_0_MitLinqFürDieSortierung();
                    break;
            }
        }

        /// <summary>
        /// Lösung mit den Möglichkeiten, die wir bisher im Unterricht gelernt haben.
        /// Inklusive Eingabevalidierung.
        /// </summary>
        [SuppressMessage("ReSharper", "TooWideLocalVariableScope")]
        [SuppressMessage("ReSharper", "InlineOutVariableDeclaration")]
        [SuppressMessage("ReSharper", "PossibleLossOfFraction")]
        private static void RunVersion_1_0()
        {
            int anzahlEinzulesenderZahlen = 3; // 10
            int[] zahlenreihe = new int[anzahlEinzulesenderZahlen];
            int zahl;
            string zahlAlsString;
            bool eingabeIstValide;

            // Zahlen einlesen
            for (int i = 0; i < anzahlEinzulesenderZahlen; i++)
            {
                Console.Write($"Zahl {i}: Geben Sie eine Ganzzahl ein: ");
                zahlAlsString = Console.ReadLine();
                eingabeIstValide = int.TryParse(zahlAlsString, out zahl);

                while (!eingabeIstValide)
                {
                    Console.Write("Die Eingabe war ungültig, bitte geben Sie eine Zahl ein: ");
                    zahlAlsString = Console.ReadLine();
                    eingabeIstValide = int.TryParse(zahlAlsString, out zahl);
                }

                zahlenreihe[i] = zahl;
            }

            // Durchschnitt berechnen
            int summe = 0;
            foreach (int aktuelleZahl in zahlenreihe)
            {
                summe += aktuelleZahl;
            }
            double durchschnitt = summe / anzahlEinzulesenderZahlen;

            // Minimum berechnen
            int minimum = zahlenreihe[0];
            foreach (int aktuelleZahl in zahlenreihe)
            {
                if (aktuelleZahl < minimum)
                {
                    minimum = aktuelleZahl;
                }
            }

            // Maximum berechnen
            int maximum = zahlenreihe[0];
            foreach (int aktuelleZahl in zahlenreihe)
            {
                if (aktuelleZahl > maximum)
                {
                    maximum = aktuelleZahl;
                }
            }

            // Damit ich eine Kopie des originalen unsortierten Datenfeldes für die Ausgabe habe, bevor das Datenfeld sortiert wird
            int[] originalZahlenreihe = new int[anzahlEinzulesenderZahlen];
            int[] aufsteigendSortierteZahlenReihe = new int[anzahlEinzulesenderZahlen];
            int[] absteigenSortierteZahlenReihe = new int[anzahlEinzulesenderZahlen];
            Array.Copy(zahlenreihe, originalZahlenreihe, zahlenreihe.Length);
            Array.Copy(zahlenreihe, aufsteigendSortierteZahlenReihe, zahlenreihe.Length);
            Array.Copy(zahlenreihe, absteigenSortierteZahlenReihe, zahlenreihe.Length);

            // Zahlen aufsteigend sortieren
            Array.Sort(aufsteigendSortierteZahlenReihe);

            // Zahlen absteigend sortieren
            Array.Sort(absteigenSortierteZahlenReihe);
            Array.Reverse(absteigenSortierteZahlenReihe);

            // Ausgabe
            Console.WriteLine("---------------------------------------");
            Console.Write("Eingegebene Zahlen: [");
            for (int i = 0; i < anzahlEinzulesenderZahlen; i++)
            {
                Console.Write($"{i}:{zahlenreihe[i]},");
            }
            Console.WriteLine("]");

            Console.Write("Aufsteigen sortiert: [");
            for (int i = 0; i < anzahlEinzulesenderZahlen; i++)
            {
                Console.Write($"{i}:{aufsteigendSortierteZahlenReihe[i]},");
            }
            Console.WriteLine("]");

            Console.Write("Absteigend sortiert: [");
            for (int i = 0; i < anzahlEinzulesenderZahlen; i++)
            {
                Console.Write($"{i}:{absteigenSortierteZahlenReihe[i]},");
            }
            Console.WriteLine("]");

            Console.WriteLine($"Durchschnitt: {durchschnitt}");
            Console.WriteLine($"Minimum:      {minimum}");
            Console.WriteLine($"Maximum:      {maximum}");
            Console.WriteLine("---------------------------------------");
        }

        /// <summary>
        /// Kürzest mögliche Version; verwendet aber Methoden, die wir nicht im Unterricht kennengelernt haben.
        /// Eingabevalidierung fehlt noch.
        /// </summary>
        private static void RunVersion_2_0()
        {
            int[] userInputs = new int[10];
            for (int i = 0; i < userInputs.Length; i++)
            {
                Console.Write($"Geben Sie bitte die Zahl {i + 1,2}/10 ein: ");
                userInputs[i] = int.Parse(Console.ReadLine() ?? string.Empty); // Bei invalider Benutzereingabe stürzt das Programm ab
            }

            // Teilaufgabe a)
            Console.WriteLine("Durchschnitt: {0}", userInputs.Average());      // Mit ReSharper und F12 die Implementierung von Average() anschauen

            // Teilaufgabe b)
            Console.WriteLine("Minimum: {0}", userInputs.Min());               // Mit ReSharper und F12 die Implementierung von Min() anschauen
            Console.WriteLine("Maximum: {0}", userInputs.Max());               // Mit ReSharper und F12 die Implementierung von Max() anschauen

            // Teilaufgabe c)
            Array.Sort(userInputs);
            Console.WriteLine("Aufsteigen sortiert: {0}", string.Join(",", userInputs));
        }

        /// <summary>
        /// Array.Sort() ist die Lösung speziell für Array.
        /// Seitdem es mit C# 3.0 (2007) das LINQ-Feature gibt, gibt auch noch diese allgemeingültige Lösung, die für alle Listen funktioniert.
        /// </summary>
        private static void RunVersion_3_0_MitLinqFürDieSortierung()
        {
            int[] array = { 7, 3, 5 };

            // LINQ-Erweiterungsmethodensyntax
            IEnumerable<int> sortierungAufsteigend = array.OrderBy(zahl => zahl); // Andere Beispiel zur Illustration, was das "zahl => zahl" bedeutet
                                                                                  // IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);

            // LINQ-Abfragesyntax
            //IEnumerable<int> sortierungAufsteigend =
            //    from zahl in array
            //    orderby zahl
            //    select zahl;

            Console.WriteLine($"Sortierte Liste: {string.Join(", ", sortierungAufsteigend)}");
        }
    }
}