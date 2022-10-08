namespace _05_Methoden_Rückgabewerte.Entitäten
{
    public class Person
    {
        public string Name { get; set; }

        public static Person ErstelleObjekt()
        {
            return new Person { Name = "Hans" };
        }

        public override string ToString()
        {
            return $"Person: Name = {Name}";
        }
    }
}