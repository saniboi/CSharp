namespace _21_Abstrakte_Klassen
{
    public class Hund : Haustier
    {
        public override string ToString()
        {
            return "Ich bin ein Hund.";
        }

        public override void MachGeräusch()
        {
            Console.WriteLine("Wuff!");
        }
    }
}