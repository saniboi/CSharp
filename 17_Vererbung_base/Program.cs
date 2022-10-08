using _17_Vererbung_base.Entitäten;

namespace _17_Vererbung_base
{
    public class Program
    {
        public static void Main()
        {
            var person = new Person("Hans");
            var studierende = new Studierende("Peter");
            Console.WriteLine($"person.Vorname = {person.Vorname}");
            Console.WriteLine($"studierende.Vorname = {studierende.Vorname}");

            var person2 = new Person("Hans", "Muster");
            var studierende2 = new Studierende("Peter", "Meier");
            Console.WriteLine($"person2.Vorname = {person2.Vorname}, person2.Nachname = {person2.Nachname}");
            Console.WriteLine($"studierende2.Vorname = {studierende2.Vorname}, studierende2.Nachname = {studierende2.Nachname}");
        }
    }
}