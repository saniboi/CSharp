using _02_Harte_Kopplung_mit_new_innerhalb_der_Klasse.EingabeUndAusgabe;

namespace _02_Harte_Kopplung_mit_new_innerhalb_der_Klasse
{
    public class Taschenrechner
    {
        public void Addiere()
        {
            var konsole = new Konsole();

            int a = konsole.LiesZahlEin(); // Harte Kopplung an die Klasse Konsole und somit die
                                           // tatsächliche Windows-Konsole wegen des statischen Aufrufes
            int b = konsole.LiesZahlEin();

            int summe = a + b;

            konsole.GibSummeAus(a, b, summe);
        }
    }
}