using System;
using System.Diagnostics.CodeAnalysis;

namespace Uebung_2_5_Enum_Wochentage
{
    public class Program
    {
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public static void Main()
        {
            // Aufgabe 2.5.2
            foreach (int enumWert in Enum.GetValues(typeof(Weekday)))
            {
                Console.WriteLine($"Weekday-Enum-Wert: {enumWert} - Weekday-Enum-Bezeichnung: {Enum.GetName(typeof(Weekday), enumWert)}");
            }

            // Aufgabe 2.5.3: direkte Konvertieren von Typ string oder int nach Enum Weekday
            Console.WriteLine();
            Console.Write("Bitte geben Sie einen Wochentag ein, z.B. \"Montag\": ");
            string wochentagAlsStringOderInt = Console.ReadLine();
            Weekday wochentagAlsEnum;
            while (!Enum.TryParse(wochentagAlsStringOderInt, out wochentagAlsEnum) && Enum.IsDefined(typeof(Weekday), wochentagAlsStringOderInt)) // https://stackoverflow.com/questions/16100/how-should-i-convert-a-string-to-an-enum-in-c
            {
                Console.Write("Der Wert ist ungültig. Bitte nochmals eingeben: ");
                wochentagAlsStringOderInt = Console.ReadLine();
            }

            //// Aufgabe 2.5.3: Alternative mit Konvertieren von Typ int nach Enum Weekday
            //Console.WriteLine();
            //Console.Write("Bitte geben Sie einen Wochentag ein, 0 bis 6: ");
            //string wochentagAlsZahlInStringForm = Console.ReadLine();
            //int wochentagAlsInt = -1;
            //bool intKonvertierungHatNichtFunktioniert = !int.TryParse(wochentagAlsZahlInStringForm, out wochentagAlsInt);
            //bool zahlLiegtAusserhalbVonNullUndSechs = wochentagAlsInt < 0 || wochentagAlsInt > 6;
            //while (intKonvertierungHatNichtFunktioniert || zahlLiegtAusserhalbVonNullUndSechs)
            //{
            //    Console.Write("Der Wert ist ungültig. Bitte nochmals eingeben: ");
            //    wochentagAlsZahlInStringForm = Console.ReadLine();
            //    intKonvertierungHatNichtFunktioniert = !int.TryParse(wochentagAlsZahlInStringForm, out wochentagAlsInt);
            //    zahlLiegtAusserhalbVonNullUndSechs = wochentagAlsInt < 0 || wochentagAlsInt > 6;
            //}
            //Weekday wochentagAlsEnum = (Weekday) wochentagAlsInt;


            // Aufgabe 2.5.4
            switch (wochentagAlsEnum)
            {
                case Weekday.Montag:
                    Console.WriteLine("Montag: Zahnarzt 08:00 - 08:30");
                    break;
                case Weekday.Dienstag:
                    Console.WriteLine("Dienstag: Home office 08:00 - 17:30");
                    break;
                default:
                    Console.WriteLine($"Keine Termine gefunden für {Enum.GetName(typeof(Weekday), wochentagAlsEnum)}");
                    break;
            }
        }
    }
}