using System;

namespace Übung_5_3_Erweiterungsmethoden
{
    public class Program
    {
        public static void Main()
        {
            double doubleZahl = 1.49383; // 5 Dezimalstellen
            int anzahlDezimalstellen = doubleZahl.AnzahlDezimalstellen();
            Console.WriteLine($"Die Zahl {doubleZahl} hat {anzahlDezimalstellen} Dezimalstellen.");
        }
    }
}