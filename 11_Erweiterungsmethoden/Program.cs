namespace _11_Erweiterungsmethoden
{
    internal class Program
    {
        private static void Main()
        {
            var text = "Erweiterungsmethode ist eine tolle Funktionalität.";
            int anzahlWörter = text.ZahleAnzahlDerWörter(); // Siehe IntelliSense-Icon
            Console.WriteLine($"Anzahl Wörter im Text: {anzahlWörter}");
        }
    }

    public static class MeineErweiterungsmethoden
    {
        public static int ZahleAnzahlDerWörter(this string derString)
        {
            return derString.Split(
                new char[] { ' ', ',', ';', '.', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries
            ).Length;
        }
    }
}