using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _07_PLINQ
{
    public class Program
    {
        public static void Main()
        {
            SequentialLinqExample();
            ParallelLinqExample();
            ParallelLinqWithNumberOfCpusExample();
        }

        private static void SequentialLinqExample()
        {
            Console.WriteLine("\n--- SequentialLinqExample ---");
            var watch = new Stopwatch();
            watch.Start();

            IEnumerable<int> numbers = Enumerable.Range(1, 10000);

            IEnumerable<int> numbersFulfillingSomeCondition =
                from number in numbers
                where Compute(number) < 10
                select number;

            foreach (int number in numbersFulfillingSomeCondition)
            {
                Console.WriteLine(number);
            }


            watch.Stop();
            Console.WriteLine($"---> elapsed time: {watch.Elapsed}");
        }

        private static int Compute(int number)
        {
            // Beispiel einer zeitintensiven Berechnung
            double result = 1;
            for (int i = 0; i < number; i++)
            {
                result = result + Math.Sin(i) * Math.Cos(i) * Math.Sqrt(i) + 1;
            }
            return (int)result;
        }

        private static void ParallelLinqExample()
        {
            Console.WriteLine("\n--- ParallelLinqExample ---");
            Console.WriteLine("Beachte: Reihenfolge der Zahlen ist anders.");

            var watch = new Stopwatch();
            watch.Start();

            IEnumerable<int> numbers = Enumerable.Range(1, 10000);

            IEnumerable<int> numbersFulfillingSomeCondition =
                from number in numbers.AsParallel() // Hier PLINQ
                where Compute(number) < 10
                select number;

            foreach (int number in numbersFulfillingSomeCondition)
            {
                Console.WriteLine(number);
            }

            watch.Stop();
            Console.WriteLine($"---> elapsed time: {watch.Elapsed}");
        }

        private static void ParallelLinqWithNumberOfCpusExample()
        {
            Console.WriteLine("\n--- ParallelLinqWithNumberOfCpusExample ---");

            var watch = new Stopwatch();
            watch.Start();

            IEnumerable<int> numbers = Enumerable.Range(1, 10000);

            IEnumerable<int> numbersFulfillingSomeCondition =
                from number in numbers
                                    .AsParallel()               // Hier PLINQ
                                    .WithDegreeOfParallelism(2) // Einschränkung auf eine Anzahl Tasks.
                                                                // Auf wieviele CPU-Cores die Tasks verteilt werden, entscheidet nicht .NET, sondern das Betriebssystem.
                where Compute(number) < 10
                select number;

            foreach (int number in numbersFulfillingSomeCondition)
            {
                Console.WriteLine(number);
            }

            watch.Stop();
            Console.WriteLine($"---> elapsed time: {watch.Elapsed}");
        }
    }
}