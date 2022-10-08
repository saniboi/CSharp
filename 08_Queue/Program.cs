using System;
using System.Collections;

namespace _08_Queue
{
    public class Program
    {
        public static void Main()
        {
            StarteQueueDemo();
        }

        private static void StarteQueueDemo()
        {
            var queue = new Queue();

            queue.Enqueue("Hello");
            queue.Enqueue("World");
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            Console.WriteLine($"--- Count ---");
            Console.WriteLine($"Count: {queue.Count}");
            Console.WriteLine($"Peek() gibt '{queue.Peek()}' zurück. Und der nächste Wert bei Dequeue() wird wieder derselbe Wert sein.");

            Console.WriteLine("\n--- while-Schleife ---");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue()); // Ausgabe: Beginn["World", "Hello", "A", "B, "C"]Ende
            }

            Console.WriteLine($"\n--- Count ---");
            Console.WriteLine($"Jetzt ist die Collection leer und enthält keine Elemente mehr: Count = {queue.Count}\n\n");

            queue.Dequeue(); // Wenn man auf einer leeren Liste ein Dequeue() aufruft, tritt eine Exception auf.
        }
    }
}