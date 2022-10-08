namespace Übung_5_1_Methoden_überladen
{
    public class Program
    {
        public static void Main()
        {
            var kalkulation = new Kalkulation();

            kalkulation.Add(1, 2); // Siehe Tooltip
            kalkulation.Add(1.1f, 2);
            kalkulation.Add(2, 3.3f);
        }
    }
}