using System;
using System.Threading;

namespace Uebung_5_1_Incrementer_Decrementer
{
    public class ThreadTester
    {
        public void DoTest()
        {
            var incremeterThreadStart = new ThreadStart(Incrementer);
            var incrementer = new Thread(incremeterThreadStart);

            var decrementerThreadStart = new ThreadStart(Decrementer);
            var decrementer = new Thread(decrementerThreadStart);

            incrementer.Start();
            decrementer.Start();
        }

        private void Incrementer()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Incrementer: {i.ToString().PadLeft(4)}");
            }
        }

        private void Decrementer()
        {
            for (int i = 100; i >= 1; i--)
            {
                Console.WriteLine($"Decrementer: \t{i.ToString().PadLeft(4)}");
            }
        }
    }
}