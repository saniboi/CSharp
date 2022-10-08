using System.Diagnostics.CodeAnalysis;

namespace _10_Klassenelemente_SichtbarkeitsmodifikatorenAssembly1
{
    public class Unterklasse : Oberklasse
    {
        private int privatesAttribut = 10;

        [SuppressMessage("ReSharper", "UnusedVariable")]
        public Unterklasse()
        {
            // Aus eigener Klasse
            // Alles sichtbar
            int a = privatesAttribut;                        // Private             Attribut    aus der eigenen Klasse ist sichtbar

            // Aus Oberklasse
            // Alles ausser private sichtbar
            //int b = privatesAttributDerVaterklasse;        // Private             Attribut    aus der Oberklasse ist nicht sichtbar
            int c = ProtectedAttributDerVaterklasse;         // Protected           Attribut    aus der Oberklasse ist sichtbar
            int d = InternalAttributDerOberklasse;           // Internal            Attribut    aus der Oberklasse ist sichtbar
            int e = InternalProtectedAttributDerOberklasse;  // Protected Internal  Attribut    aus der Oberklasse ist sichtbar
            int f = PublicAttributDerOberklasse;             // Public              Attribut    aus der Oberklasse ist sichtbar
            int g = PublicEigenschaftDerOberklasse;          // Public              Eigenschaft aus der Oberklasse ist sichtbar
        }
    }
}