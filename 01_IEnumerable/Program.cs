using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace _01_IEnumerable
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;
            switch (beispiel)
            {
                case 1:
                    ForeachBeispiel();
                    break;
                case 2:
                    EnumeratorBeispiel();
                    break;
            }
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void ForeachBeispiel()
        {
            int[] intArray = { 1, 5, 2 };

            // foreach kann mit allen Collections arbeiten, die das Interface IEnumerable implementieren.
            // Jedes Array implementiert IEnumerable. Darum kann man foreach mit Arrays verwenden.
            // Siehe Dokumentation https://docs.microsoft.com/en-us/dotnet/api/system.array
            foreach (int aktuellesIntElement in intArray)
            {
                Console.WriteLine($"foreach: {aktuellesIntElement}");
            }

            IEnumerable iEnumerable = intArray; // Weil ein Array auch ein IEnumerable ist, geht dieses implizite Casting
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private static void EnumeratorBeispiel()
        {
            int[] intArray = { 1, 5, 2 };

            // foreach ist hinter den Kulissen in etwa so implementiert: http://stackoverflow.com/questions/398982/how-do-foreach-loops-work-in-c
            // Weitere Diskussion wie foreach implementiert ist: https://stackoverflow.com/a/20311361/33311
            IEnumerator enumerator = intArray.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current != null)
                {
                    int value = (int)enumerator.Current;
                    Console.WriteLine($"Current = {value}");
                }
            }

            // Beachte: Man hat keinen sog. wahlfreien Zugriff. Das heisst, um z.B. auf das 3. Element zu gelangen,
            //          muss man sich mit 3mal MoveNext() vorwärts bewegen.
        }
    }
}