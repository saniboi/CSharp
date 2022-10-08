namespace _05_Konstanten
{
    /// <summary>
    /// Quelle: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants
    /// </summary>
    public class Program
    {
        public const double Pi = 3.14; // Namenskonvention für Klassenkonstanten: PascalCasing

        public static void Main()
        {
            Console.WriteLine($"Pi = {Pi}");

            const double pi2 = 3.14; // Namenskonvention für lokale Konstanten: lowerCasing

            Console.WriteLine($"pi2 = {pi2}");

            //pi2 = 3; // Konstanten können nicht mehr verändert werden (wie die Bezeichnung "Konstante" schon ausdrückt)

            // Nutzen von Konstanten
            // - Unveränderbarkeit: Schützt davor, dass der Wert nicht aus Versehen verändert wird
            // - Lesbarkeit: Ersetzt "magische Zahlen" im Code durch sprechende Bezeichnungen; z.B. const double MWST = 7.7
            // - Wartbarkeit: Wert kann zentral an einem Ort angepasst werden
        }
    }
}