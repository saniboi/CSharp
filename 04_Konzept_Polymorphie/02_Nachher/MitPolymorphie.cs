using System;
using _04_Konzept_Polymorphie.Entitäten;

namespace _04_Konzept_Polymorphie._02_Nachher
{
    public class MitPolymorphie
    {
        public void LasseBeispielLaufen()
        {
            // Mit Polymorphie
            //
            // Eine Implementierung, die mit allen Typen "Mitarbeiter" umgehen kann;
            // d.h., wenn ein neuer Mitarbeitertyp hinzukommt, muss folgender Code
            // nicht angepasst werden!

            // Berechnung der Personalausgaben
            Mitarbeiter[] mitarbeiter = MitarbeiterFabrik.ErstelleListeVonUnterschiedlichenMitarbeitern();
            int lohnausgaben = 0;
            foreach (Mitarbeiter aktuelleMitarbeiter in mitarbeiter)
            {
                int lohn = aktuelleMitarbeiter.BerechneLohn();
                string name = aktuelleMitarbeiter.Name;
                Console.WriteLine($"Lohn ausrechnen: {name}, {lohn}");
                lohnausgaben += lohn;
            }

            Console.WriteLine($"Lohnausgaben: {lohnausgaben}");
            Console.WriteLine("--------------------------------------");
        }
    }
}