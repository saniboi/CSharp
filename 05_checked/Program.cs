namespace _05_checked
{
    public class Program
    {
        public static void Main()
        {
            OverflowExceptionMitCheckedSchlüsselwort();
        }

        private static void OverflowExceptionMitCheckedSchlüsselwort()
        {
            int number = 0;
            try
            {
                checked
                {
                    Console.WriteLine($"--- Werte ---");
                    Console.WriteLine($"number = {number}");
                    number = int.MaxValue;
                    Console.WriteLine($"number = {number} nach Zuweisung von int.MaxValue");

                    Console.WriteLine($"number++ = {number++}"); // Hier tritt die Exception auf
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"--- Mein Log-Eintrag ---\nEin Überflauf hat in der Variablen '{nameof(number)}' stattgefunden. Aktueller Wert: {number}.\n");
                Console.WriteLine($"--- e.Message ---\n{e.Message}\n");
                Console.WriteLine($"--- e.StackTrace ---\n{e.StackTrace}\n");
                // Aufräumaktionen hier oder im finally ausführen
            }
        }
    }
}