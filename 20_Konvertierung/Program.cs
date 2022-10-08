using System.Diagnostics.CodeAnalysis;
using _20_Konvertierung.Entitäten;

namespace _20_Konvertierung
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int ausgewähltesBeispiel = 1;

            switch (ausgewähltesBeispiel)
            {
                case 1:
                    KonvertierungMitAs();
                    break;
                case 2:
                    CastingZumAllgemeinerenTyp();
                    break;
                case 3:
                    CastingZumKonkreterenTyp();
                    break;
                case 4:
                    BoxingUndUnboxing();
                    break;
                case 5:
                    BoxingUndUnboxing2();
                    break;
            }
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        [SuppressMessage("ReSharper", "UseNegatedPatternMatching")]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        private static void KonvertierungMitAs()
        {
            Tier tier = new Käfer();

            // tier.PrintColor();   // Aufruf von PrintColor auf einem Tier ist nicht möglich,
            // weil ein Tier keine PrintColor-Methode hat; nur ein Käfer hat jene Methode.

            // Beispiel einer Konvertierung, die geht: Tier in Käfer
            Käfer käfer = tier as Käfer; // Konvertierung ist erfolgreich: käfer ist nicht null
            if (käfer != null)
            {
                Console.WriteLine("käfer-if-Fall");
                käfer.PrintColor();
            }
            else
            {
                Console.WriteLine("käfer-else-Fall");
                Console.WriteLine("Der Inhalt der Variablen tier ist kein Käfer! Die Konvertierung ist fehlgeschlagen.");
            }
            Console.WriteLine("---");

            // Obigen Code kann man mit der Pattern-Matching-Syntax auch so schreiben
            if (tier is Käfer käfer2) // Und null ist nicht vom Typ "Käfer", also muss man hier keine zusätzliche Null-Überprüfung durchführen
            {
                Console.WriteLine("käfer2-if-Fall");
                käfer2.PrintColor();
            }
            else
            {
                Console.WriteLine("käfer2-else-Fall");
                Console.WriteLine("Der Inhalt der Variablen tier ist kein Käfer! Die Konvertierung ist fehlgeschlagen.");
            }
            Console.WriteLine("---");

            // Beispiel einer Konvertierung, die nicht geht: Hund in Käfer
            Hund hund = tier as Hund; // Konvertierung schlägt fehl: hund ist null
            if (hund == null)
            {
                Console.WriteLine("hund-if-Fall");
                Console.WriteLine("Der Inhalt der Variablen tier ist kein Hund, sondern ein Käfer! Die Konvertierung ist fehlgeschlagen.");
            }
        }

        [SuppressMessage("ReSharper", "RedundantCast")]
        private static void CastingZumAllgemeinerenTyp()
        {
            Hund hund = new Hund();
            Tier tier = (Tier)hund;
            Console.WriteLine(tier);
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void CastingZumKonkreterenTyp()
        {
            // Casting zum konkreteren Typ funktioniert, wenn beim new bereits eine Unterklasse benutzt wird
            Tier tier = new Hund();
            Hund hund = (Hund)tier;
            Console.WriteLine(hund.ToString());

            // Casting zum konkreteren Typ funktioniert nicht, wenn beim new Oberklasse benutzt wird
            Tier tier2 = new Tier();
            //Hund hund2 = (Hund)tier2; // Funktioniert nicht; Programm stürzt ab
            //Console.WriteLine(hund2.ToString());
        }

        [SuppressMessage("ReSharper", "RedundantAssignment")]
        [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
        private static void BoxingUndUnboxing()
        {
            int i = 123;
            object box;
            box = i;

            i = (int)box;

            // Man kann auf einer Zahl eine Methode ToString() aufrufen,
            // weil 10 ein Int32 ist und Int32 ein Struct ist und
            // ein Struct ein object ist und auf object
            // eine Methode ToString() definiert ist.
            10.ToString();
        }

        /// <summary>
        /// Konvertierung (englisch: casting)
        ///     1) Implizite Konvertierung
        ///             1a) Allgemeiner Fall
        ///             1b) Spezieller Fall: Wertetyp in Referenztyp object (engl. boxing)
        ///     2) Explizite Konvertierung
        ///             2a) Allgemeiner Fall
        ///             2b) Spezieller Fall: Referenztyp in Wertetyp object (engl. unboxing)
        ///
        /// Dokumentation
        ///     https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
        /// </summary>
        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void BoxingUndUnboxing2()
        {
            int intX = 1;
            int intY = 2;

            object objectX = intX;      // Implizites Boxing
            object objectY = intY;      // Implizites Boxing

            int intX2 = (int)objectX;  // Explizites Unboxing
            int intY2 = (int)objectY;  // Explizites Unboxing

            int intZ = (int)objectX + (int)objectY;
        }
    }
}