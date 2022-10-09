using System.Threading;

namespace Uebung_5_6_Incrementer_Decrementer
{
    public class MinMaxThreadreferenceTuple
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public Thread OtherThread { get; private set; }

        public MinMaxThreadreferenceTuple(int min, int max, Thread otherThread)
        {
            Min = min;
            Max = max;
            OtherThread = otherThread;
        }
    }
}