using System;
using System.Collections;

namespace Übung_6_1_Mitarbeiterverzeichnis_mit_Hastable
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
            var mitarbeiter1 = new Mitarbeiter
            {
                Personalnummer = 1,
                Vorname = "Hans",
                Nachname = "Müller",
                Telefonnummer = "123"
            };
            var mitarbeiter2 = new Mitarbeiter
            {
                Personalnummer = 2,
                Vorname = "Peter",
                Nachname = "Muster",
                Telefonnummer = "456"
            };
            var mitarbeiter3 = new Mitarbeiter
            {
                Personalnummer = 3,
                Vorname = "Peter",
                Nachname = "Muster 3",
                Telefonnummer = "456 3"
            };
            verzeichnis.FügeMitarbeiterHinzu(mitarbeiter1);
            verzeichnis.FügeMitarbeiterHinzu(mitarbeiter2);
            verzeichnis.FügeMitarbeiterHinzu(mitarbeiter3);
        }

        public void AbfragenÜberDiePersonalnummerAusführen()
        {
            Console.WriteLine("--- AbfragenÜberDiePersonalnummerAusführen() ---");
            object ergebnis1 = verzeichnis.FindeMitarbeiterMitPersonalnummer(1);
            Console.WriteLine($"ergebnis1 = {ergebnis1}");
        }

        public void WasGeschietBeiEinerAbfrageWoDerSchlüsselNichtExistiert()
        {
            Console.WriteLine("\n--- WasGeschietBeiEinerAbfrageWoDerSchlüsselNichtExistiert() ---");
            object ergebnis2 = verzeichnis.FindeMitarbeiterMitPersonalnummer(0); // 0 als Personalnummer existiert nicht im Verzeichnis
            Console.WriteLine($"ergebnis2 = {ergebnis2}");
        }

        public void AbfragenÜberMitareitervornamenAusführen()
        {
            Console.WriteLine("\n--- AbfragenÜberMitareitervornamenAusführen() ---");
            ArrayList ergenbis3 = verzeichnis.FindeMitarbeiterMitVornamen("Peter");
            foreach (object mitarbeiter in ergenbis3)
            {
                Console.WriteLine($"ergebnis3 = {mitarbeiter}");
            }
        }
    }
}