using System;
using System.Diagnostics.CodeAnalysis;

namespace Übung_3_1_Klasse
{
    /// <summary>
    /// Die Klasse repräsentiert einen Mitarbeiter und alle seine Daten.
    /// Die Daten können über die Konsole ein- und ausgegeben werden.
    /// 
    /// Fehleingaben des Benutzers werden noch nicht validiert und führen
    /// zu einem Programmabsturz.
    /// </summary>
    public class Mitarbeiter // Klassen in separate Dateien auslagern
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Personalnummer { get; set; }
        public DateTime Eintrittsdatum { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public double Salär { get; set; } // decimal wäre auch ein geeigneter Datentyp gewesen
        public string PrivateAdresse { get; set; }

        /// <summary>
        /// string, weil damit möglich ist vorangehende Nullen
        /// abzubilden; z.B. mit int wäre das nicht möglich
        /// </summary>
        public string Telefonnummer { get; set; } 

        /// <summary>
        /// Liest die Mitarbeiterdaten aus der Konsole ein.
        /// Bei falscher Dateneingabe stürzt das Programm ab.
        /// </summary>
        public void DatenEinlesen() // public, weil die Methode von aussen aufrufbar sein soll
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Bitte geben Sie folgenden Daten des Mitarbeiters ein:");
            Console.WriteLine("-----------------------------------------------------");
            Vorname = TextEinlesen("Vorname: ");
            Nachname = TextEinlesen("Nachname: ");
            Personalnummer = ZahlEinlesen("Personalnummer: ");
            Eintrittsdatum = DatumEinlesen("Eintrittsdatum (im Format YYYY-MM-DD): ");
            Geburtsdatum = DatumEinlesen("Geburtstag (im Format YYYY-MM-DD): ");
            PrivateAdresse = TextEinlesen("Private Adresse (im Format Strasse Nr., PLZ Ort): ");
            Telefonnummer = TextEinlesen("Telefonnummer (im Format 0041 12 345 67 89): ");
        }

        /// <summary>
        /// Alle Daten des Mitarbeiters werden auf die Konsole ausgegeben.
        /// </summary>
        public void DatenAusgeben() // public, weil die Methode von aussen aufrufbar sein soll
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Die Mitarbeiterdaten sind:");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Vorname: {0}", Vorname);
            Console.WriteLine("Nachname:  {0}", Nachname);
            Console.WriteLine("Personalnummer: {0}", Personalnummer);
            Console.WriteLine("Eintrittsdatum: {0}", Eintrittsdatum);
            Console.WriteLine("Geburtstag: {0}", Geburtsdatum);
            Console.WriteLine("Private Adresse: {0}", PrivateAdresse);
            Console.WriteLine("Telefonnummer: {0}", Telefonnummer);
        }

        /// <summary>
        /// Liest einen Text aus der Konsole ein.
        /// </summary>
        /// <param name="eingabeaufforderungstext">
        /// Der Text, den der Benutzer in der Konsole als Eingabenaufforderung sieht.
        /// Beispiel: eingabeaufforderungstext = "Bitte geben Sie den Vornamen ein: ".
        /// </param>
        /// <returns>
        /// Gibt die Konsoleneingabe des Benutzers zurück.
        /// </returns>
        private string TextEinlesen(string eingabeaufforderungstext) // private, weil das eine nur intern genutzte Hilfsmethode ist
        {
            Console.Write(eingabeaufforderungstext); // Nur Write und nicht WriteLine, damit der Benutzer
                                                     // die Eingabe auf der gleichen Zeile vornehmen kann,
                                                     // wo der Eingabeaufforderungstext steht
            string benutzereingabe = Console.ReadLine();
            return benutzereingabe;
        }

        /// <summary>
        /// Liest ein Datum aus der Konsole ein.
        /// Enthält die Benutzereingabe Fehler und wird sie nicht in ein DateTime
        /// umgewandelt werden und ein Ausnahmefall tritt auf.
        /// </summary>
        /// <param name="eingabeaufforderungstext">
        /// Der Text, den der Benutzer in der Konsole als Eingabenaufforderung sieht.
        /// Beispiel: eingabeaufforderungstext = "Bitte geben Sie den Vornamen ein: ".
        /// </param>
        /// <returns>
        /// Gibt die Konsoleneingabe des Benutzers als DateTime konvertiert zurück.
        /// Fehler in der Benutzereingabe führen zum Programmabsturz.
        /// </returns>
        private DateTime DatumEinlesen(string eingabeaufforderungstext)
        {
            Console.Write(eingabeaufforderungstext);
            string benutzereingabe = Console.ReadLine();
            DateTime datum = DateTime.Parse(benutzereingabe);
            return datum;
        }

        /// <summary>
        /// Liest einen Text aus der Konsole ein.
        /// </summary>
        /// <param name="eingabeaufforderungstext">
        /// Der Text, den der Benutzer in der Konsole als Eingabenaufforderung sieht.
        /// Beispiel: eingabeaufforderungstext = "Bitte geben Sie den Vornamen ein: ".
        /// </param>
        /// <returns>
        /// Gibt die Konsoleneingabe des Benutzers zurück als int konvertiert zurück.
        /// Fehler in der Benutzereingabe führen zum Programmabsturz.
        /// </returns>
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        private int ZahlEinlesen(string eingabeaufforderungstext)
        {
            Console.Write(eingabeaufforderungstext);
            string benutzereingabe = Console.ReadLine();
            int zahl = int.Parse(benutzereingabe);
            return zahl;
        }
    }
}