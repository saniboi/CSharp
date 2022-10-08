using _10_Klassenelemente_SichtbarkeitsmodifikatorenAssembly1;

namespace _10_Klassenelemente_SichtbarkeitsmodifikatorenAssembly2
{
    public class UnterklasseInAndererAssembly : Oberklasse
    {

        public UnterklasseInAndererAssembly()
        {
            // Von der Klasse Oberklasse, von der wir hier erben, aus der anderen Assembly,
            // sehen wir alles protected und protected internal und public Attribute und Eigenschaften

            //int b = privatesAttributDerVaterklasse;          // Private             Attribut    aus der Oberklasse ist nicht sichtbar
            int c = ProtectedAttributDerVaterklasse;           // Protected           Attribut    aus der Oberklasse ist sichtbar
            //int d = InternalAttributDerOberklasse;           // Internal            Attribut    aus der Oberklasse ist nicht sichtbar
            int e = InternalProtectedAttributDerOberklasse;    // Protected Internal  Attribut    aus der Oberklasse ist nicht sichtbar
            int f = PublicAttributDerOberklasse;               // Public              Attribut    aus der Oberklasse ist sichtbar
            int g = PublicEigenschaftDerOberklasse;            // Public              Eigenschaft aus der Oberklasse ist sichtbar
        }
    }
}