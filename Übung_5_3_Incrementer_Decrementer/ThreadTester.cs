using System;
using System.Threading;

namespace Uebung_5_3_Incrementer_Decrementer
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

            incrementer.Start(new MinMaxTuple(1, 500));
            decrementer.Start(new MinMaxTuple(700, 1000));
        }

        private void Incrementer(object parameter)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;
            var minMaxTuple = (MinMaxTuple) parameter;

            for (int i = minMaxTuple.Min; i <= minMaxTuple.Max; i++)
            {
                Console.WriteLine($"Incrementer Id={threadId} Name={threadName}: {i.ToString().PadLeft(4)}");
                Thread.Sleep(10);
            }
        }

        private void Decrementer(object parameter)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;
            var minMaxTuple = (MinMaxTuple)parameter;
          
            for (int i = minMaxTuple.Max; i >= minMaxTuple.Min; i--)
            {
                Console.WriteLine($"Decrementer Id={threadId} Name={threadName}: {i.ToString().PadLeft(4)}");
                Thread.Sleep(10);
            }
        }
    }
}