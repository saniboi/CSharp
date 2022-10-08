#pragma warning disable 184
using System;
using System.Diagnostics.CodeAnalysis;

namespace IstStringEinArray
{
    public class Program
    {
        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        public static void Main()
        {
            // Schauen, was ein konkreter Objekt für einen Typ hat
            string hans = "Hans";
            Type typDesStringHans = hans.GetType();
            Console.WriteLine($"Typ: {typDesStringHans}");

            bool istStringEinArray = hans.GetType() is Array;
            bool istStringEinIComparable = hans.GetType() is IComparable; // "hans" ist erst ein IComparable, nachdem wir in IComparable casten

            Console.WriteLine($"istStringEinArray: {istStringEinArray}");
            Console.WriteLine($"istStringEinIComparable: {istStringEinIComparable}");


            // F12 auf string ausführen, um den Code dahinter zu sehen ← Das funktioniert nur, wenn wir ReSharper installiert haben.
            // Sonst einen anderen Decompiler nehmen oder auf https://referencesource.microsoft.com/#mscorlib/system/string.cs,254 schauen
        }
    }
}
