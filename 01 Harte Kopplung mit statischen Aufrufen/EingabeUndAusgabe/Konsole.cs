using System;

namespace _01_Harte_Kopplung_mit_statischen_Aufrufen.EingabeUndAusgabe
{
    public class Konsole
    {
        public static int LiesZahlEin()
        {
            Console.Write("Bitte eine Zahl eingeben: ");
            string benutzereingabeAlsString = Console.ReadLine();
            int benutzereingabeAlsInteger = int.Parse(benutzereingabeAlsString); // Der Einfachheit halber wurde hier die Validierung weggelassen
            return benutzereingabeAlsInteger;
        }

        public static void GibSummeAus(int a, int b, int summe)
        {
            Console.WriteLine($"Die Summer der Addition von {a} und {b} ist {summe}.");
        }
    }
}