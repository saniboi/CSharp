using System;
using System.Threading;

namespace Uebung_5_5_Incrementer_Decrementer
{
    public class ThreadTester
    {
        public void DoTest()
        {
            var incremeterThreadStart = new ParameterizedThreadStart(Incrementer);
            var incrementer = new Thread(incremeterThreadStart);
            incrementer.Name = "Incr.";

            var decrementerThreadStart = new ParameterizedThreadStart(Decrementer);
            var decrementer = new Thread(decrementerThreadStart);
            decrementer.Name = "Decr.";

            incrementer.Start(new MinMaxThreadreferenceTuple(1, 500, decrementer));
            decrementer.Start(new MinMaxThreadreferenceTuple(700, 1000, null));
        }

        private void Incrementer(object parameter)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;
            var minMaxTuple = (MinMaxThreadreferenceTuple)parameter;

            for (int i = minMaxTuple.Min; i <= minMaxTuple.Max; i++)
            {
                Console.WriteLine($"Incrementer Id={threadId} Name={threadName}: {i.ToString().PadLeft(4)}");
                Thread.Sleep(10);
                if (i == 100)
                {
                    var minMaxThreadreferenceTuple = (MinMaxThreadreferenceTuple)parameter;
                    minMaxThreadreferenceTuple.OtherThread.Join(); // Wait until other thread has finished
                }
            }
        }

        private void Decrementer(object parameter)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;
            var minMaxTuple = (MinMaxThreadreferenceTuple)parameter;

            for (int i = minMaxTuple.Max; i >= minMaxTuple.Min; i--)
            {
                Console.WriteLine($"Decrementer Id={threadId} Name={threadName}: {i.ToString().PadLeft(4)}");
                Thread.Sleep(10);
            }
        }
    }
}