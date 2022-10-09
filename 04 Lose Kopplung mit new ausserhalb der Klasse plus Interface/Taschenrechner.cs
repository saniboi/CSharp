using _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Ausgabe;
using _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Eingabe;

namespace _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface
{
    public class Taschenrechner
    {
        private IEingabe eingabeSchnittstelle;
        private IAusgabe ausgabeSchnittstelle;

        public Taschenrechner(IEingabe eingabeSchnittstelle, IAusgabe ausgabeSchnittstelle)
        {
            this.eingabeSchnittstelle = eingabeSchnittstelle;
            this.ausgabeSchnittstelle = ausgabeSchnittstelle;
        }

        public void Addiere()
        {
            //var konsole = new Konsole(); // Kein new mehr innerhalb der Klasse Taschenrechner
                                           // Die Konsole wird von aussen reingegeben

            int a = eingabeSchnittstelle.LiesZahlEin(); // Harte Kopplung an die Klasse Konsole und somit die
                                           // tatsächliche Windows-Konsole wegen des statischen Aufrufes
            int b = eingabeSchnittstelle.LiesZahlEin();

            int summe = a + b;

            ausgabeSchnittstelle.GibSummeAus(a, b, summe);
        }
    }
}