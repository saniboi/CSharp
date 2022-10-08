namespace _14_Klassenelemente_Statischer_Konstruktor
{
    public class Klasse2
    {
        static Klasse2()
        {
            Console.WriteLine("Klasse2                       : Der statische Klasse2.Konstruktor() wurde ausgeführt.");
        }

        public Klasse2()
        {
            Console.WriteLine("Klasse2                       : Der nicht-statische Klasse2.Konstruktor() wurde ausgeführt.");
        }

        ~Klasse2()
        {
            Console.WriteLine("Klasse2                       : Der Destruktor wird ausgeführt.");
        }
    }
}