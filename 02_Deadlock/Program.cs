using System;
using System.Threading;

namespace _02_Deadlock
{
    class Program
    {
        static void Main()                                              // Thread 1
        {
            // Diese zwei Variablen vom Typ Object repräsentieren
            // in diesem Beispiel zwei Ressourcen, die zwischen
            // den Prozesse geteilt werden.
            // In Realität könnte das z.B. zwei Dateien sein.
            Object ressourceA = new Object();
            Object ressourceB = new Object();

            new Thread(() =>                                        // Thread 2
            {
                Console.WriteLine("Thread 2: vor lock(obj1)");
                lock (ressourceA)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Thread 2: vor lock(obj2)");
                    lock (ressourceB);                                        // Deadlock
                    Console.WriteLine("Thread 2: nach lock(obj2)");
                }
                Console.WriteLine("Thread 2: nach lock(obj1)");
            }).Start();

            Console.WriteLine("Thread 1: vor lock(obj2)");
            lock (ressourceB)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 1: vor lock(obj1)");
                lock (ressourceA);                                            // Deadlock
                Console.WriteLine("Thread 1: nach lock(obj2)");
            }
            Console.WriteLine("Thread 1: nach lock(obj2)");
            Console.WriteLine("Ende.");
        }
    }
}
