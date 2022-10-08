using _04_Konzept_Polymorphie.Entitäten;

namespace _04_Konzept_Polymorphie._01_Vorher
{
    public class OhnePolymorphie
    {
        public void LasseBeispielLaufen()
        {
            Chef chef = new Chef { Name = "Uwe" };                                                                  // Chef als Chef instanziieren (wie bisher)
            Büezer büezer1 = new Büezer { Name = "Peter" };                                                         // Büezer als Büezer instanziieren (wie bisher)
            Büezer büezer2 = new Büezer { Name = "Patrick" };                                                       // Büezer als Büezer instanziieren (wie bisher)
            Produktionsmitarbeiter produnktionsmitarbeiter = new Produktionsmitarbeiter { Name = "Hans" };           // Produktionsmitarbeiter als Produktionsmitarbeiter instanziieren (wie bisher)
            Personalverantwortlicher personalverantwortlicher = new Personalverantwortlicher { Name = "Sandra" };   // Personalverantwortlicher als Personalverantwortlicher instanziieren (wie bisher)

            // Ohne Polymorphie
            //
            // Für jeden Typ braucht es eine separate Implementierung;
            // d.h., will man die Applikation erweitern, muss man bestehenden Code ändern

            // Berechnung der Personalausgaben
            object[] mitarbeiter = { chef, büezer1, büezer2, produnktionsmitarbeiter, personalverantwortlicher };
            int lohnausgaben = 0;
            foreach (object aktuelleMitarbeiter in mitarbeiter)
            {
                if (aktuelleMitarbeiter is Chef)
                {
                    int lohn = ((Chef)aktuelleMitarbeiter).BerechneLohn();
                    string name = ((Chef)aktuelleMitarbeiter).Name;
                    Console.WriteLine($"Lohn ausrechnen: {name}, {lohn}");
                    lohnausgaben += lohn;
                }
                else if (aktuelleMitarbeiter is Büezer)
                {
                    int lohn = ((Büezer)aktuelleMitarbeiter).BerechneLohn();
                    string name = ((Büezer)aktuelleMitarbeiter).Name;
                    Console.WriteLine($"Lohn ausrechnen: {name}, {lohn}");
                    lohnausgaben += lohn;
                }
                else if (aktuelleMitarbeiter is Produktionsmitarbeiter)
                {
                    int lohn = ((Produktionsmitarbeiter)aktuelleMitarbeiter).BerechneLohn();
                    string name = ((Produktionsmitarbeiter)aktuelleMitarbeiter).Name;
                    Console.WriteLine($"Lohn ausrechnen: {name}, {lohn}");
                    lohnausgaben += lohn;
                }
                else if (aktuelleMitarbeiter is Personalverantwortlicher)
                {
                    int lohn = ((Personalverantwortlicher)aktuelleMitarbeiter).BerechneLohn();
                    string name = ((Personalverantwortlicher)aktuelleMitarbeiter).Name;
                    Console.WriteLine($"Lohn ausrechnen: {name}, {lohn}");
                    lohnausgaben += lohn;
                }
            }

            Console.WriteLine($"Lohnausgaben: {lohnausgaben}");
            Console.WriteLine("--------------------------------------");
        }
    }
}