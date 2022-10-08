using System.Collections;
using System.Diagnostics.CodeAnalysis;
// ReSharper disable InvalidXmlDocComment

namespace _02_ICollection
{
    /// <summary>
    /// The ICollection interface is the base interface for classes in the System.Collections namespace.
    /// Its generic equivalent is the System.Collections.Generic.ICollection<T> interface. 
    /// - https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection?view=net-6.0
    ///
    /// Implementierungen von ICollection sind:
    /// - https://docs.microsoft.com/en-us/dotnet/api/system.collections?view=net-6.0
    /// - https://stackoverflow.com/questions/28247883/simple-existing-implementation-of-icollectiont
    /// </summary>
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;
            switch (beispiel)
            {
                case 1:
                    ICollectionCount();
                    break;
                case 2:
                    ICollectionCopyTo();
                    break;
                case 3:
                    ICollectionIsSynchronized();
                    break;
                case 4:
                    RunICollectionSyncRoot();
                    break;
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static void ICollectionCount()
        {
            int[] intArray = { 1, 5, 2 };

            ICollection collection = intArray;

            Console.WriteLine($"Count: {intArray.Length}");
            Console.WriteLine($"Count: {collection.Count}"); // Das Collection-Count kapselt das Array.Length.
                                                             // http://referencesource.microsoft.com/#mscorlib/system/array.cs,680
                                                             // Das Count kommt aus dem ICollection-Interface.
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static void ICollectionCopyTo()
        {
            int[] intArray = { 1, 5, 2 };

            int[] kopiertesArray = new int[intArray.Length + 1];

            intArray.CopyTo(kopiertesArray, 1); // Kopiert [1, 5, 2] in ein
                                                // [0, 1, 5, 2] ab Index 1; vorne Nullen

            Console.WriteLine($"kopiertesArray[0] = {kopiertesArray[0]}");
            Console.WriteLine($"kopiertesArray[1] = {kopiertesArray[1]}");
            Console.WriteLine($"kopiertesArray[2] = {kopiertesArray[2]}");
            Console.WriteLine($"kopiertesArray[3] = {kopiertesArray[3]}");
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static void ICollectionIsSynchronized()
        {
            int[] intArray = { 1, 5, 2 };
            ICollection collection = intArray;
            Console.WriteLine($"IsSynchronized: {collection.IsSynchronized}"); // https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/#thread-synchronization-in-the-net-framework-10-and-20-collections
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.array.syncroot
        /// </summary>
        [SuppressMessage("ReSharper", "RedundantExplicitArrayCreation")]
        private static void RunICollectionSyncRoot()
        {
            Array intArray = new int[] { 1, 2, 4 };
            lock (intArray.SyncRoot)
            {
                Console.WriteLine("--- Erstes foreach ---");
                foreach (object aktuellesIntElement in intArray)
                {
                    intArray.SetValue(10, 0);
                    Console.WriteLine(aktuellesIntElement);
                }

                intArray.SetValue(10, 0);

                Console.WriteLine("--- Zweites foreach ---");
                foreach (object aktuellesIntElement in intArray)
                {
                    intArray.SetValue(10, 0);
                    Console.WriteLine(aktuellesIntElement);
                }
            }
        }
    }
}