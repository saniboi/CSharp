using System;
using _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Eingabe;

namespace _05_Testing_mit_04_Lose_Kopplung.Eingabe
{
    public class KonsolenEingabePlatzhalter : IEingabe
    {
        private int counter;
        private const int ErsterMethodenAufruf = 1;
        private const int ZweiterMethodenAufruf = 2;

        public int RückgabewertFürDenErstenMethodenAufruf { get; set; }
        public int RückgabewertFürDenZweitenMethodenAufruf { get; set; }
        
        public int LiesZahlEin()
        {
            counter++;
            
            if (counter == ErsterMethodenAufruf)
            {
                return RückgabewertFürDenErstenMethodenAufruf;
            }
            else if (counter == ZweiterMethodenAufruf)
            {
                return RückgabewertFürDenZweitenMethodenAufruf;
            }

            throw new Exception(
                "Die Methode wurde mehr als zweimal aufgerufen und dieser Fall ist für die Tests nicht erwartet");
        }
    }
}
