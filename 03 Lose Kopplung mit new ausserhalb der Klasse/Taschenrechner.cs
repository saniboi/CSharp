using _03_Lose_Kopplung_mit_new_ausserhalb_der_Klasse.EingabeUndAusgabe;

namespace _03_Lose_Kopplung_mit_new_ausserhalb_der_Klasse
{
    public class Taschenrechner
    {
        private Konsole konsole;

        public Taschenrechner(Konsole konsole)
        {
            this.konsole = konsole;
        }

        public void Addiere()
        {
            //var konsole = new Konsole(); // Kein new mehr innerhalb der Klasse Taschenrechner
                                           // Die Konsole wird von aussen reingegeben

            int a = konsole.LiesZahlEin(); // Lose Kopplung
            int b = konsole.LiesZahlEin();

            int summe = a + b;

            konsole.GibSummeAus(a, b, summe);
        }
    }
}