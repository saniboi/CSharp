using System;

namespace Übung_3_1_Klasse_v3_0
{
    public class Mitarbeiter
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string PrivateAdresse { get; set; }
        public int Personalnummer { get; set; }
        public int Salaer { get; set; }
        public int Telefonnummer { get; set; }
        public DateTime Eintrittsdatum { get; set; }
        public DateTime Geburtsdatum { get; set; }

        private readonly DatenEinlesenKonsole datenEinlesenKonsole;
        private readonly DatenAusgebenKonsole datenAusgebenKonsole;

        public Mitarbeiter(DatenEinlesenKonsole datenEinlesenKonsole, DatenAusgebenKonsole datenAusgebenKonsole)
        {
            this.datenEinlesenKonsole = datenEinlesenKonsole;
            this.datenAusgebenKonsole = datenAusgebenKonsole;
        }

        public void LiesEin()
        {
            Vorname = datenEinlesenKonsole.VornameEinlesen(); //Sämtliche Einlese-Operationen wiederum in eine eigene Klasse verschoben. Macht die Klasse Mitarbeiter übersichtlicher, führt aber zu höherer Komplexität da mehr Klassen vorhanden. Sinnvoll?
            Nachname = datenEinlesenKonsole.NachnameEinlesen();
            Personalnummer = datenEinlesenKonsole.PersonalnummerEinlesen();
            Eintrittsdatum = datenEinlesenKonsole.EintrittsdatumEinlesen();
            Geburtsdatum = datenEinlesenKonsole.GeburtsdatumEinlesen();
            Salaer = datenEinlesenKonsole.SalaerEinlesen();
            PrivateAdresse = datenEinlesenKonsole.AdresseEinlesen();
            Telefonnummer = datenEinlesenKonsole.TelefonnummerEinlesen();
        }
        
        public void GibAus()
        {
            datenAusgebenKonsole.GibAus(this);
        }
    }
}
