namespace _11_Klassenelemente_Destruktor
{
    public class KlasseMitDestruktor
    {
        // Der Destruktur muss gleich heissen wie die Klasse
        // und mit einer Tilde "~" beginnen
        ~KlasseMitDestruktor()
        {
            Console.WriteLine("Der Destruktor wird ausgeführt.");
        }
    }
}