using System;
using System.Threading;

namespace Uebung_5_4_Incrementer_Decrementer
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
            decrementer.Start(new MinMaxThreadreferenceTuple(501, 1000, null));
            //Thread.CurrentThread.Sleep(1000);
            //decrementer.Abort(); // Rausnehmen
            //incrementer.Join();
            //decrementer.Join();
            //decrementer.Abort();
            //Console.WriteLine("Ende");
        }

        private void Incrementer(object parameter)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;
            var minMaxTuple = (MinMaxThreadreferenceTuple) parameter;

            for (int i = minMaxTuple.Min; i <= minMaxTuple.Max; i++)
            {
                Console.WriteLine($"Incrementer Id={threadId} Name={threadName}: {i.ToString().PadLeft(4)}");
                Thread.Sleep(10);
                if (i == 200)
                {
                    var minMaxThreadreferenceTuple = (MinMaxThreadreferenceTuple) parameter;
                    minMaxThreadreferenceTuple.OtherThread.Abort(); // Invoke Abort() on other thread
                }
            }
        }

        private void Decrementer(object parameter)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name;
            var minMaxTuple = (MinMaxThreadreferenceTuple)parameter;

            try
            {
                for (int i = minMaxTuple.Max; i >= minMaxTuple.Min; i--)
                {
                    Console.WriteLine($"Decrementer Id={threadId} Name={threadName}: {i.ToString().PadLeft(4)}");
                    Thread.Sleep(10);
                }
            }
            catch (ThreadAbortException e) // React to Abort() from other thread
            {
                Console.WriteLine($"...doing some cleanup on thread {threadName}...");
                Console.WriteLine(e);
            }
        }
    }
}