using _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Ausgabe;

namespace _05_Testing_mit_04_Lose_Kopplung.Ausgabe
{
    public class KonsolenAusgabePlatzhalter : IAusgabe
    {
        public int WertVonSummandA { get; set; }
        public int WertVonSummandB { get; set; }
        public int WertVonSumme { get; set; }

        public void GibSummeAus(int a, int b, int summe)
        {
            WertVonSummandA = a;
            WertVonSummandB = b;
            WertVonSumme = summe;
        }
    }
}
