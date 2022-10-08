using System;

namespace _12_Generische_Klasse_GenericStack
{
    public class Program
    {
        private static void Main()
        {
            StarteGenericStackBeispiel();
        }

        private static void StarteGenericStackBeispiel()
        {
            var stack = new GenericStack<int>(5);

            stack.Push(32);
            stack.Push(983);
            stack.Push(44);

            Console.WriteLine("--- for-Schleife ---");
            for (int inx = stack.Length; inx >= 0; inx--)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("\n--- Push() + Pop() ---");
            stack.Push(60);
            Console.WriteLine($"stack.Pop(): {stack.Pop()}");
        }
    }
}