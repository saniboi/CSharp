using System;

namespace Übung_3_1_Klasse_v2_0
{
    internal class MitarbeiterKonsolenSchreiber
    {
        /// <summary>
        /// Alle Daten des Mitarbeiters werden auf die Konsole ausgegeben.
        /// </summary>
        public void MitarbeiterAusgeben(Mitarbeiter mitarbeiter) // public, weil die Methode von aussen aufrufbar sein soll
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Die Mitarbeiterdaten sind:");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Vorname: {0}", mitarbeiter.Vorname);
            Console.WriteLine("Nachname:  {0}", mitarbeiter.Nachname);
            Console.WriteLine("Personalnummer: {0}", mitarbeiter.Personalnummer);
            Console.WriteLine("Eintrittsdatum: {0}", mitarbeiter.Eintrittsdatum);
            Console.WriteLine("Geburtstag: {0}", mitarbeiter.Geburtsdatum);
            Console.WriteLine("Private Adresse: {0}", mitarbeiter.PrivateAdresse);
            Console.WriteLine("Telefonnummer: {0}", mitarbeiter.Telefonnummer);
        }
    }
}