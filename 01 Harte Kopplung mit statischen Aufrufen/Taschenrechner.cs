using _01_Harte_Kopplung_mit_statischen_Aufrufen.EingabeUndAusgabe;

namespace _01_Harte_Kopplung_mit_statischen_Aufrufen
{
    public class Taschenrechner
    {
        public void Addiere()
        {
            int a = Konsole.LiesZahlEin(); // Harte Kopplung an die Klasse Konsole und somit die
                                           // tatsächliche Windows-Konsole wegen des statischen Aufrufes
            int b = Konsole.LiesZahlEin();

            int summe = a + b;

            Konsole.GibSummeAus(a, b, summe);
        }
    }
}