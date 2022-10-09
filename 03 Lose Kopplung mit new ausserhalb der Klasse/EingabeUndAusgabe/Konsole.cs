using System;

namespace _03_Lose_Kopplung_mit_new_ausserhalb_der_Klasse.EingabeUndAusgabe
{
    public class Konsole
    {
        public int LiesZahlEin() // Ist nicht mehr statisch wie im vorherigen Beispiel
        {
            Console.Write("Bitte eine Zahl eingeben: ");
            string benutzereingabeAlsString = Console.ReadLine(); // Todo: Validierung der Einfachheit halber für dieses Beispiel
            int benutzereingabeAlsInteger = int.Parse(benutzereingabeAlsString);
            return benutzereingabeAlsInteger;
        }

        public void GibSummeAus(int a, int b, int summe) // Ist nicht mehr statisch wie im vorherigen Beispiel
        {
            Console.WriteLine($"Die Summer der Addition von {a} und {b} ist {summe}.");
        }
    }
}