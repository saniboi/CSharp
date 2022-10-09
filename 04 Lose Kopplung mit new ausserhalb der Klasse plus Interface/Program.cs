using _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Ausgabe;
using _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Eingabe;

namespace _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface
{
    /// <summary>
    /// 04 Lose Kopplung mit new ausserhalb der Klasse plus Interface
    /// </summary>
    internal class Program
    {

        private static void Main()
        {
            IEingabe eingabeSchnittstelle = new KonsolenEingabe();
            IAusgabe ausgabeSchnittstelle = new KonsolenAusgabe();
            var taschenrechner = new Taschenrechner(eingabeSchnittstelle, ausgabeSchnittstelle);
            taschenrechner.Addiere();

            // Ausgangslage
            // Die Klasse Taschenrechner macht statische Aufrufe, um Daten auf die Konsole zu schreiben.
            //
            // Aufgabe
            // Der Kunde wünscht, dass alle Ausgaben neu in eine Datei gehen statt auf die Konsole.
            // Baue das Programm entsprechend um.

            IAusgabe dateiSchnittstelle = new Dateiausgabe();
            taschenrechner = new Taschenrechner(eingabeSchnittstelle, dateiSchnittstelle);
            taschenrechner.Addiere();

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
