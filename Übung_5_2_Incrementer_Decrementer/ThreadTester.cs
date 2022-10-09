using System;
using System.Threading;

namespace Uebung_5_2_Incrementer_Decrementer
{
    public class ThreadTester
    {
        public void DoTest()
        {
            var incremeterThreadStart = new ThreadStart(Incrementer);
            var incrementer = new Thread(incremeterThreadStart);
            incrementer.Name = "Incr.";

            var decrementerThreadStart = new ThreadStart(Decrementer);
            var decrementer = new Thread(decrementerThreadStart);
            decrementer.Name = "Decr.";

            incrementer.Start();
            decrementer.Start();
        }

        private void Incrementer()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;
            int hashCode = Thread.CurrentThread.GetHashCode();

            for (int i = 1; i <= 1000; i++)
            {
                Console.WriteLine($"Incrementer Id={threadId} Name={threadName} Hashcode={hashCode}: {i.ToString().PadLeft(4)}");
                Thread.Sleep(10);
            }
        }

        private void Decrementer()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;

            for (int i = 1000; i >= 1; i--)
            {
                Console.WriteLine($"Decrementer Id={threadId} Name={threadName}: \t\t{i.ToString().PadLeft(4)}");
                Thread.Sleep(10);
            }
        }
    }
}