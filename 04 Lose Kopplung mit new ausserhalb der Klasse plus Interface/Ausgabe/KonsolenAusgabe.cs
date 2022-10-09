using System;

namespace _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Ausgabe
{
    internal class KonsolenAusgabe : IAusgabe
    {
        public void GibSummeAus(int a, int b, int summe)
        {
            Console.WriteLine($"Die Summer der Addition von {a} und {b} ist {summe}.");
        }
    }
}