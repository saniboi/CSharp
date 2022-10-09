namespace _01_Harte_Kopplung_mit_statischen_Aufrufen
{
    public class Program
    {
        public static void Main()
        {
            var taschenrechner = new Taschenrechner();
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
