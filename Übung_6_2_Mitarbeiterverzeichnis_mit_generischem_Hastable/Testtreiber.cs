using System;
using System.Collections.Generic;

namespace Übung_6_2_Mitarbeiterverzeichnis_mit_generischem_Hastable
{
    public class Testtreiber
    {
        private Mitarbeiterverzeichnis verzeichnis;

        public void MitarbeiterverzeichnisInstanziieren()
        {
            verzeichnis = new Mitarbeiterverzeichnis();
        }

        public void EinPaarMitarbeiterInsVerzeichnisAufnehmen()
        {
            var kunde1 = new Mitarbeiter
            {
                Personalnummer = 1,
                Vorname = "Hans",
                Nachname = "Müller",
                Firma = "HFU",
                Telefonnummer = "123"
            };
            var kunde2 = new Mitarbeiter
            {
                Personalnummer = 2,
                Vorname = "Peter",
                Nachname = "Muster",
                Firma = "HFU",
                Telefonnummer = "456"
            };
            var kunde3 = new Mitarbeiter
            {
                Personalnummer = 3,
                Vorname = "Peter",
                Nachname = "Muster 3",
                Firma = "HFU 3",
                Telefonnummer = "456 3"
            };
            verzeichnis.FügeMitarbeiterHinzu(kunde1);
            verzeichnis.FügeMitarbeiterHinzu(kunde2);
            verzeichnis.FügeMitarbeiterHinzu(kunde3);
        }

        public void AbfragenÜberDiePersonalnummerAusführen()
        {
            Console.WriteLine("--- AbfragenÜberDiePersonalnummerAusführen() ---");
            Mitarbeiter ergebnis1 = verzeichnis.FindeMitarbeiterMitMitarbeiternummer(1);
            Console.WriteLine($"ergebnis1 = {ergebnis1}");
        }

        public void WasGeschietBeiEinerAbfrageWoDerSchlüsselNichtExistiert()
        {
            Console.WriteLine("\n--- WasGeschietBeiEinerAbfrageWoDerSchlüsselNichtExistiert() ---");
            int personalnummer = 0;
            try
            {
                Mitarbeiter ergebnis2 = verzeichnis.FindeMitarbeiterMitMitarbeiternummer(personalnummer); // 0 als Personalnummer existiert nicht im Verzeichnis
                Console.WriteLine("ergebnis2 - {0}", ergebnis2);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("Es existiert kein Mitarbeiter mit Personalnummer {0} im Kundenverzeichnis", personalnummer);
                Console.WriteLine(e.Message);
            }
        }

        public void AbfragenÜberMitareitervornamenAusführen()
        {
            Console.WriteLine("\n--- AbfragenÜberMitareitervornamenAusführen() ---");
            List<Mitarbeiter> ergenbis3 = verzeichnis.FindeMitarbeiterMitVornamen("Peter");
            foreach (Mitarbeiter kunden in ergenbis3)
            {
                Console.WriteLine("ergebnis3 - {0}", kunden);
            }
        }
    }
}