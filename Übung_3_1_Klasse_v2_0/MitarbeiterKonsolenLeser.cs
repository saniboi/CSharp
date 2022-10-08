using System;
using System.Diagnostics.CodeAnalysis;

namespace Übung_3_1_Klasse_v2_0
{
    internal class MitarbeiterKonsolenLeser
    {
        public Mitarbeiter MitarbeiterEinlesen() // public, weil die Methode von aussen aufrufbar sein soll
        {
            var mitarbeiter = new Mitarbeiter();

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Bitte geben Sie folgenden Daten des Mitarbeiters ein:");
            Console.WriteLine("-----------------------------------------------------");
            mitarbeiter.Vorname = TextEinlesen("Vorname: ");
            mitarbeiter.Nachname = TextEinlesen("Nachname: ");
            mitarbeiter.Personalnummer = ZahlEinlesen("Personalnummer: ");
            mitarbeiter.Eintrittsdatum = DatumEinlesen("Eintrittsdatum (im Format YYYY-MM-DD): ");
            mitarbeiter.Geburtsdatum = DatumEinlesen("Geburtstag (im Format YYYY-MM-DD): ");
            mitarbeiter.PrivateAdresse = TextEinlesen("Private Adresse (im Format Strasse Nr., PLZ Ort): ");
            mitarbeiter.Telefonnummer = TextEinlesen("Telefonnummer (im Format 0041 12 345 67 89): ");

            return mitarbeiter;
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
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
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