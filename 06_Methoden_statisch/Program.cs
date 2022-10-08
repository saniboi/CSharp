using System.Diagnostics.CodeAnalysis;

namespace _06_Methoden_statisch
{
    internal class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    StatischeMethoden();
                    break;
                case 2:
                    ZweiUnterschiedlicheObjekteAberMitGleicherStatischerMethodeUndVariable();
                    break;
            }
        }

        private static void StatischeMethoden()
        {
            int siebenPlusEins = MeineKlasse.MeineStatischeMethodeDieEinsAddiert(7);
            Console.WriteLine($"{nameof(siebenPlusEins)} = {siebenPlusEins}");

            double umfang = Formeln.KreisUmfang(321.23);
            Console.WriteLine($"{nameof(umfang)} = {umfang}");
        }

        private static void ZweiUnterschiedlicheObjekteAberMitGleicherStatischerMethodeUndVariable()
        {
            Person peter = new Person { Vorname = "Peter", Nachname = "Meier" };
            Person sara = new Person { Vorname = "Sara", Nachname = "Müller" };
            Person.StatischeMethodeKannNurAufStatischeVariablenZugreifen("Uster");
            Console.WriteLine(peter);
            Console.WriteLine(sara);

            Person.StatischeMethodeKannNurAufStatischeVariablenZugreifen("Zürich");
            Console.WriteLine(peter);
            Console.WriteLine(sara);

            sara.NichtStatischeMethodeKannAufStatischeVariablenZugreifen("Bern");
            Console.WriteLine(peter);
            Console.WriteLine(sara);
        }
    }

    internal class MeineKlasse
    {
        public static int MeineStatischeMethodeDieEinsAddiert(int wert)
        {
            return ++wert; // "++wert" ist korrekt. "wert++" gibt 7 zurück und nicht 8, wie man meinen könnte, und wäre somit hier falsch
        }
    }

    internal class Formeln
    {
        public static double KreisUmfang(double radius)
        {
            return 2 * Math.PI * radius;
        }
    }

    internal class Person
    {
        public static string Wohnort { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public static void StatischeMethodeKannNurAufStatischeVariablenZugreifen(string neuerWohnort)
        {
            Wohnort = neuerWohnort; // Zugriff auf statische Variable ist möglich
            //Vorname = "Sara";     // Fehlermeldung: Cannot access non-static property 'Vorname' in static context.
            //Nachname = "Müller";  // Fehlermeldung: Cannot access non-static property 'Vorname' in static context.
        }

        public void NichtStatischeMethodeKannAufStatischeVariablenZugreifen(string neuerWohnort)
        {
            Wohnort = neuerWohnort;
            Vorname = "Sara2";     // Das funktioniert
            Nachname = "Müller2";  // Das funktioniert
        }

        public override string ToString()
        {
            return $"{nameof(Vorname)} = {Vorname}, {nameof(Nachname)} = {Nachname}, {nameof(Wohnort)} = {Wohnort},";
        }
    }
}