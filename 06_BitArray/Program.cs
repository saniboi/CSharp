using System;
using System.Collections;

namespace _06_BitArray
{
    public class Program
    {
        public static void Main()
        {
            StarteBitArrayDemo();
        }

        private static void StarteBitArrayDemo()
        {
            bool[] array = new bool[5];
            array[0] = true;
            array[1] = false; // False ist der Standardwert, wenn man nichts setzt
            array[2] = true;
            array[3] = false;
            array[4] = true;

            BitArray bitArray = new BitArray(array);

            Console.WriteLine("--- foreach ---");
            GibBitArrayAus(bitArray);

            Console.WriteLine("\n--- foreach nach Änderung des ersten Wertes ---");
            bitArray.Set(0, false);
            GibBitArrayAus(bitArray);

            Console.WriteLine("\n--- foreach nach Not() ---");
            bitArray.Not();
            GibBitArrayAus(bitArray);
            Console.WriteLine("---");
        }

        private static void GibBitArrayAus(BitArray bitArray)
        {
            foreach (bool bit in bitArray)
            {
                Console.WriteLine(bit);
            }
        }
    }
}