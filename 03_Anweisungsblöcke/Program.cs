using System.Diagnostics.CodeAnalysis;

namespace _03_Anweisungsblöcke
{
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Main 1");
            {
                Console.WriteLine("Main 2");
                Console.WriteLine("Main 3");
            }

            //BeispielEinerMethode();
            //BeispielMitGültigkeitsbereichVonVariablen();
        }

        /// <summary>
        /// Damit wir die zukünftigen Beispiele in Methoden auslagern und so besser strukturieren können,
        /// führen wir an dieser Stelle das Konzept der "Methoden" kurz ein, welche wir später in
        /// Kapitel 03 "OOP" und Kapitel 05 "Methoden" in Detail kennenlernen werden.
        ///
        /// Beispiel: Mit "private static void MethodenName() { ... }" können wir ein Stück Code "auslagern/separieren".
        /// </summary>
        private static void BeispielEinerMethode()
        {
            Console.WriteLine("--- BeispielEinerMethode ---");
            Console.WriteLine("BeispielEinerMethode 1");
            Console.WriteLine("BeispielEinerMethode 2");
            Console.WriteLine("BeispielEinerMethode 3");
        }

        private static void BeispielMitGültigkeitsbereichVonVariablen()
        {
            Console.WriteLine("--- BeispielMitGültigkeitsbereichVonVariablen ---");

            //int i = 10;       // Zeile aktivieren und Fehlermeldung in der "Error List"-Ansicht lesen
            // Error CS0136  A local or parameter named 'i' cannot be declared in this scope because that name is used in an enclosing local scope to define a local or parameter

            Console.WriteLine("1");
            {
                Console.WriteLine("2");
                Console.WriteLine("3");
                int i = 20;
                Console.WriteLine(i);
                int j = 30;
                Console.WriteLine(j);
            }
            {
                int i = 40;
                Console.WriteLine(i);
                //Console.WriteLine(j); // Zeile aktivieren und Fehlermeldung in der "Error List"-Ansicht lesen
                // Error CS0103  The name 'j' does not exist in the current context Anweisungblöcke
            }
        }
    }
}
