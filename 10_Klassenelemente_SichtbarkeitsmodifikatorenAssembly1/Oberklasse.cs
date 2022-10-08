using System.Diagnostics.CodeAnalysis;

namespace _10_Klassenelemente_SichtbarkeitsmodifikatorenAssembly1
{
    public class Oberklasse
    {
        private int privatesAttributDerVaterklasse = 1;
        protected int ProtectedAttributDerVaterklasse = 2;
        internal int InternalAttributDerOberklasse = 3;

        /// <summary>
        /// Heisst protected _oder_ (nicht "und") internal:
        /// http://haacked.com/archive/2007/10/29/what-does-protected-internal-mean.aspx/
        /// 
        /// Selten verwendet.
        /// Z.B. wenn ich einer anderen Assembly2
        /// eine Klasse von Assembly1.Oberklasse
        /// erben sollte.
        /// </summary>
        protected internal int InternalProtectedAttributDerOberklasse = 4;

        public int PublicAttributDerOberklasse = 5; // Statt diesem öffentlichen Attribut, lieber eine Eigentschaft verwenden
        public int PublicEigenschaftDerOberklasse { get; set; }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        public Oberklasse()
        {
            // Hier in der Oberklasse sind alle Attribute sichtbar von private bis public und alles dazwischen
            int a = privatesAttributDerVaterklasse;          // Private             Attribut    aus der eigenen Klasse ist sichtbar
            int b = privatesAttributDerVaterklasse;          // Private             Attribut    aus der eigenen Klasse ist sichtbar
            int c = ProtectedAttributDerVaterklasse;         // Protected           Attribut    aus der eigenen Klasse ist sichtbar
            int d = InternalAttributDerOberklasse;           // Internal            Attribut    aus der eigenen Klasse ist sichtbar
            int e = InternalProtectedAttributDerOberklasse;  // Protected Internal  Attribut    aus der eigenen Klasse ist sichtbar
            int f = PublicAttributDerOberklasse;             // Public              Attribut    aus der eigenen Klasse ist sichtbar
            int g = PublicEigenschaftDerOberklasse;          // Public              Eigenschaft aus der eigenen Klasse ist sichtbar
        }
    }
}