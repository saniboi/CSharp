namespace _21_Abstrakte_Klassen
{
    public class Katze : Haustier
    {
        public override string ToString()
        {
            return "Ich bin eine Katze.";
        }

        public override void MachGeräusch()
        {
            Console.WriteLine("Miau!");
        }
    }
}