using System;

namespace Übung_3_1_Klasse_v3_0
{
    public class DatenEinlesenKonsole
    {
        public string VornameEinlesen()
        {
            Console.WriteLine("Bitte den Vornamen eingeben:");
            return Console.ReadLine();
        }
        public string NachnameEinlesen()
        {
            Console.WriteLine("Bitte den Nachname eingeben:");
            return Console.ReadLine();
        }

        public string AdresseEinlesen()
        {
            Console.WriteLine("Bitte die Adresse eingeben:");
            return Console.ReadLine();
        }

        public int PersonalnummerEinlesen()
        {
            Console.WriteLine("Bitte Personalnummer (nur aus Zahlen bestehend) eingeben:");
            int personalnummerchecked;
            while (!int.TryParse(Console.ReadLine(), out personalnummerchecked))
            {
                Console.WriteLine("Keine gültige Personalnummer eingegeben! Bitte erneut eingeben:");
            }
            return personalnummerchecked;
        }

        public int SalaerEinlesen()
        {
            Console.WriteLine("Bitte Salär (nur aus Zahlen bestehend) eingeben:");
            int salaerchecked;
            while (!int.TryParse(Console.ReadLine(), out salaerchecked))
            {
                Console.WriteLine("Keine gültiges Salär eingegeben! Bitte erneut eingeben:");
            }
            return salaerchecked;
        }

        public int TelefonnummerEinlesen()
        {
            Console.WriteLine("Bitte Telefonnummer eingeben:");
            Console.Write("0041");
            int telnummerchecked;
            while (!int.TryParse(Console.ReadLine(), out telnummerchecked))
            {
                Console.WriteLine("Keine gültigen Daten eingegeben! Bitte erneut eingeben:");
                Console.Write("0041");
            }
            return telnummerchecked;
        }

        public DateTime EintrittsdatumEinlesen()
        {
            Console.WriteLine("Bitte Eintrittsdatum im Format DD.MM.YYYY oder DD/MM/YYYY eingeben:");
            string eingabeeintritt = Console.ReadLine();
            DateTime eintrittsdatum;
            while (!DateTime.TryParseExact(eingabeeintritt, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,  out eintrittsdatum))
            {
                Console.WriteLine("Ungültige Eingabe! Bitte erneut im Format DD.MM.YYYY oder DD/MM/YYYY eingeben.");
                eingabeeintritt = Console.ReadLine();
            }

            return eintrittsdatum;
        }

        public DateTime GeburtsdatumEinlesen()
        {
            Console.WriteLine("Bitte Geburtsdatum im Format DD.MM.YYYY oder DD/MM/YYYY eingeben:");
            string eingabeeintritt = Console.ReadLine();
            DateTime geburtsdatum;
            while (!DateTime.TryParseExact(eingabeeintritt, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out geburtsdatum))
            { 
                Console.WriteLine("Ungültige Eingabe! Bitte erneut im Format DD.MM.YYYY oder DD/MM/YYYY eingeben.");
                eingabeeintritt = Console.ReadLine();
            }

            return geburtsdatum;
        }
    }
}
