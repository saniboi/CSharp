namespace _14_Klassenelemente_Statischer_Konstruktor
{

    internal class Klasse1
    {
        // Vorschlag: vermeiden hier vor dem Konstruktor schon Variablen zu setzen
        // Grund: Methoden HoleWert1() und HoleWert2() werden vor bzw. nach dem Konstruktur aufgerufen, was man nicht unbedingt erwarten würde.
        // Empfehlung: Initialisierungen im Konstruktor durchführen statt hier.
        private static string meineStatischeVariable = HoleWert1();
        private string meineNichtStatischeVariable = HoleWert2();

        static Klasse1()
        {
            Console.WriteLine("Klasse1                       : Der statische Klasse1.Konstruktor() wurde ausgeführt.");
        }

        public Klasse1()
        {
            Console.WriteLine("Klasse1                       : Der nicht-statische Klasse1.Konstruktor() wurde ausgeführt.");
        }

        ~Klasse1()
        {
            Console.WriteLine("Klasse1                       : Der Destruktor wird ausgeführt.");
        }

        private static string HoleWert1()
        {
            Console.WriteLine("Klasse1                       : meineStatischeVariable wird gesetzt.");
            return "Test";
        }

        private static string HoleWert2() // Beachte: "static" entfernen und Fehlermeldung beachten
            // Error CS0236  A field initializer cannot reference the non-static field, method, or property 'Klasse1.HoleWert2()'

        {
            Console.WriteLine("Klasse1                       : meineNichtStatischeVariable wird gesetzt.");
            return "Test";
        }
    }
}