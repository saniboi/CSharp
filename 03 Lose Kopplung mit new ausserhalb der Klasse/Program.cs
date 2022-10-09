using _03_Lose_Kopplung_mit_new_ausserhalb_der_Klasse.EingabeUndAusgabe;

namespace _03_Lose_Kopplung_mit_new_ausserhalb_der_Klasse
{
    internal class Program
    {
        private static void Main()
        {
            var konsole = new Konsole();
            var taschenrechner = new Taschenrechner(konsole); // Dependency-Injection
            taschenrechner.Addiere();

            // Ausgangslage
            // Die Klasse Taschenrechner macht statische Aufrufe, um Daten auf die Konsole zu schreiben.
            //
            // Aufgabe
            // Der Kunde wünscht, dass alle Ausgaben neu in eine Datei gehen statt auf die Konsole.
            // Baue das Programm entsprechend um.
            //
            // Reflektion
            // Was musste alles angepasst werden für diese Anpassung?
            // Wieviel Aufwand war es?
            //
            // Aufgabe
            // Der Kunde wünscht, dass für die Addition immer automatisch die 2 und 3 verwendet wird (zwei beliebige
            // für die Übung ausgwählte zahlen) und die Werte nicht aus der Konsole kommen.
            //
            // Reflektion
            // Was musste alles angepasst werden für diese Anpassung?
            // Wieviel Aufwand war es?
        }
    }
}
