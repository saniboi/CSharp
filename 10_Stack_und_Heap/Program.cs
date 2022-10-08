using System.Diagnostics.CodeAnalysis;

namespace _10_Stack_und_Heap
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        public static void Main()
        {
            // Hier werden diverse Werte- und Referenztypen eine nach der anderen deklariert, initialisiert und neu gesetzt
            int i = 1;
            int j = i;
            i = 2;
            Person p1 = new Person();
            p1.Name = "Hans";
            p1.Alter = 25;
            Person p2 = new Person();
            p2.Name = "Sara";
            p2.Alter = 26;
            p1 = p2;
            p1.Alter = 30;

            WertetypIntVerändern(j);
            Console.WriteLine($"i = {i}");
            Console.WriteLine($"j = {j}");

            ReferenztypPersonObjektVerändern(p2);
            Console.WriteLine($"p1.Alter = {p1.Alter}");
            Console.WriteLine($"p2.Alter = {p2.Alter}");
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static void WertetypIntVerändern(int x)
        {
            x = 3;
        }

        private static void ReferenztypPersonObjektVerändern(Person person)
        {
            person.Alter = 31;
        }
    }

    internal class Person
    {
        public string Name { get; set; }
        public int Alter { get; set; }
    }
}