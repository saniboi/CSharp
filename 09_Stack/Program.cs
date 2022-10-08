using System;
using System.Collections;

namespace _09_Stack
{
    public class Program
    {
        public static void Main()
        {
            StartStackDemo();
        }

        private static void StartStackDemo()
        {
            Stack stack = new();

            stack.Push("Hello");
            stack.Push("World");
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");

            Console.WriteLine($"Count: {stack.Count}");
            Console.WriteLine($"Peek() gibt {stack.Peek()} zurück. Und der Count in der nächsten Zeile ist unverändert.");
            Console.WriteLine($"Count: {stack.Count}");

            Console.WriteLine("\n--- while-Schleife ---");
            while (stack.Count > 0)
            {
                Console.WriteLine($"Pop() = '{stack.Pop()}'. Aktueller Count nach dem letzten Pop() = {stack.Count}");
            }

            // stack.Pop(); // Führt zu einer InvalidOperationException
        }
    }
}