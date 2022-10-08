using _04_Konzept_Polymorphie.Entitäten;

namespace _04_Konzept_Polymorphie._02_Nachher
{
    public class MitarbeiterFabrik
    {
        public static Mitarbeiter[] ErstelleListeVonUnterschiedlichenMitarbeitern()
        {
            Chef chef = new Chef { Name = "Uwe" };                                                                  // Chef als Chef instanziieren (wie bisher)
            Büezer büezer1 = new Büezer { Name = "Peter" };                                                         // Büezer als Büezer instanziieren (wie bisher)
            Büezer büezer2 = new Büezer { Name = "Patrick" };                                                       // Büezer als Büezer instanziieren (wie bisher)
            Produktionsmitarbeiter produnktionsmitarbeiter = new Produktionsmitarbeiter { Name = "Hans" };          // Produktionsmitarbeiter als Produktionsmitarbeiter instanziieren (wie bisher)
            Personalverantwortlicher personalverantwortlicher = new Personalverantwortlicher { Name = "Sandra" };   // Personalverantwortlicher als Personalverantwortlicher instanziieren (wie bisher)

            // Aber zurückgeben tun wir eine Liste von Mitarbeitern, d.h. die Abstraktion (sprich "Gegen die Abstraktion programmieren")
            // Mitarbeiter m = new Chef(); // Nicht Chef m = new Chef();
            return new Mitarbeiter[] { chef, büezer1, büezer2, produnktionsmitarbeiter, personalverantwortlicher }; // Ist neu (nicht wie bisher)
        }
    }
}