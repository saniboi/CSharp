
using System;

namespace Übung_3_1_Klasse_v3_0
{
    public class Program
    {
        private static void Main()
        {
            var datenausgabe = new DatenAusgebenKonsole();
            var dateneingabe = new DatenEinlesenKonsole();

            //var datenausgabe = new DatenAusgebenDatenbank();
            //var dateneingabe = new DatenEinlesenDatenbank();

            var mitarbeiter = new Mitarbeiter(dateneingabe, datenausgabe); // Constructor dependency injection

            mitarbeiter.LiesEin();
            mitarbeiter.GibAus();

            Console.ReadLine(); //Damit das Programm nicht gleich beendet wird
        }
    }
}
