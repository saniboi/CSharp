using _10_Klassenelemente_SichtbarkeitsmodifikatorenAssembly1;

namespace _10_Klassenelemente_SichtbarkeitsmodifikatorenAssembly2
{
    public class KlasseD
    {
        public KlasseD()
        {
            // Von der Klasse Oberklasse (von der wir her NICHT erben) aus der anderen Assembly
            // sehe wir nur die public Attribute und Eigenschaften:

            Oberklasse o = new Oberklasse();
            //int b = o.privatesAttributDerVaterklasse;          // Private             Attribut    aus der Oberklasse ist nicht sichtbar
            //int c = o.ProtectedAttributDerVaterklasse;         // Protected           Attribut    aus der Oberklasse ist nicht sichtbar
            //int d = o.InternalAttributDerOberklasse;           // Internal            Attribut    aus der Oberklasse ist nicht sichtbar
            //int e = o.InternalProtectedAttributDerOberklasse;  // Protected Internal  Attribut    aus der Oberklasse ist nicht sichtbar
            int f = o.PublicAttributDerOberklasse;               // Public              Attribut    aus der Oberklasse ist sichtbar
            int g = o.PublicEigenschaftDerOberklasse;            // Public              Eigenschaft aus der Oberklasse ist sichtbar
        }
    }
}