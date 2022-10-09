namespace Uebung_5_3_Incrementer_Decrementer
{
    public class MinMaxTuple
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public MinMaxTuple(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}