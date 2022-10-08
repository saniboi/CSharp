using System.Diagnostics.CodeAnalysis;

#pragma warning disable 168

namespace _03_try_catch_finally
{
    public class Program
    {
        public static void Main()
        {
            TryCatchFinally();
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void TryCatchFinally()
        {
            Console.WriteLine("1. Beginn (wird auf jeden Fall ausgeführt)");
            try
            {
                FileInfo source = new FileInfo("dieseDateiExistiertNicht.pdf");
                int length = (int)source.Length; // Hier wird die Exception geworfen
                Console.WriteLine("2. Zwischenschritt (wird nicht ausgeführt)");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("3. Aufräumarbeiten, die ausgeführt werden");
                FileInfo source = new FileInfo("dieseDateiExistiertNicht.pdf");
                int length = (int)source.Length; // Hier wird die Exception geworfen
                Console.WriteLine("4. Aufräumarbeiten, die _nicht_ ausgeführt werden");
            }
            finally
            {
                Console.WriteLine("5. Ende (muss / soll auf jeden Fall ausgeführt werden)");
            }
        }
    }
}