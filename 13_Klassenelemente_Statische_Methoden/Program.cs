namespace _13_Klassenelemente_Statische_Methoden
{
    public class Program
    {
        public static void Main()
        {
            // Aufruf einer statische Methode, analog wie bei statischen
            // Attributen und Eigenschaften, über den Klassennamen; nicht
            // über den Instanznamen.
            Elektrizität.BerechneLeistung(2, 3);

            //Elektrizität elektrizität = new Elektrizität();
            //elektrizität.BerechneLeistung(2, 3); // Geht nicht, weil es eine statische Methode ist
        }
    }
}