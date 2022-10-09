using System;

namespace _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Eingabe
{
    internal class KonsolenEingabe : IEingabe
    {
        public int LiesZahlEin()
        {
            Console.Write("Bitte eine Zahl eingeben: ");
            string benutzereingabeAlsString = Console.ReadLine();
            int benutzereingabeAlsInteger = int.Parse(benutzereingabeAlsString);
            return benutzereingabeAlsInteger;
        }
    }
}