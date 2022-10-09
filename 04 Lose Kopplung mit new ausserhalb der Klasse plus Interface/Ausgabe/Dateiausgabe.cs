using System;
using System.IO;

namespace _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Ausgabe
{
    internal class Dateiausgabe : IAusgabe
    {
        public void GibSummeAus(int a, int b, int summe)
        {
            Console.WriteLine("Log: Die Ausgabe ging in eine Datei 'ausgabe.txt'.");
            File.WriteAllText("ausgabe.txt", $"Die Summer der Addition von {a} und {b} ist {summe}.");
        }
    }
}