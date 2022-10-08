namespace Übung_3_1_Klasse_v2_0
{
    internal class Program
    {
        static void Main()
        {
            // Mitarbeiter-Variable deklarieren
            Mitarbeiter mitarbeiter;

            // Mitarbeiter einlesen
            var leser = new MitarbeiterKonsolenLeser();
            mitarbeiter = leser.MitarbeiterEinlesen();

            // Mitarbeiter ausgeben
            var schreiber = new MitarbeiterKonsolenSchreiber();
            schreiber.MitarbeiterAusgeben(mitarbeiter);
        }
    }
}