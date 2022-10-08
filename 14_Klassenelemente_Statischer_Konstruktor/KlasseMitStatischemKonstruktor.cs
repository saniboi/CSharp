namespace _14_Klassenelemente_Statischer_Konstruktor
{
    public class KlasseMitStatischemKonstruktor
    {
        public static int StatischesAttribut = 1;

        // Wird bei der ersten Verwendung der Klasse instanziiert, z.B
        // auch bei einem statischen Zugriff
        private Klasse1 klasse1 = new Klasse1();

        // Wird erst bei der Instanziierung der Klasse
        // "KlasseMitStatischemKonstruktor" im Konstruktor instanziiert
        private Klasse2 klasse2;


        /// <summary>
        /// Statische Konstruktoren können keinen Sichtbarkeitsmodifikator wie public haben.
        /// 
        /// Es gibt nur einen parameterlosen statischen Konstruktor, keine mit Parametern:
        /// http://stackoverflow.com/a/6771909
        /// </summary>
        static KlasseMitStatischemKonstruktor()
        {
            Console.WriteLine("KlasseMitStatischemKonstruktor: Der statische Konstruktor wird ausgeführt.");
        }

        public KlasseMitStatischemKonstruktor()
        {
            Console.WriteLine("KlasseMitStatischemKonstruktor: Der nicht-statische Konstruktor wird ausgeführt.");
            klasse2 = new Klasse2();
        }

        ~KlasseMitStatischemKonstruktor()
        {
            Console.WriteLine("KlasseMitStatischemKonstruktor: Der Destruktor wird ausgeführt.");
        }
    }
}