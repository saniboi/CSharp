using System.Diagnostics.CodeAnalysis;

namespace _16_Vererbung_new
{
    public class Program
    {
        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        public static void Main()
        {
            Console.WriteLine("--- Basisklasse person1 = new Basisklasse()");
            Parent person1;             // Deklaration mit Basisklasse
            person1 = new Parent();     // Initialisierung auch mit Basisklasse
            person1.WriteHello();       // Kein polymorphes Verhalten, weil nicht als virtual deklariert
            person1.WriteSeeYou();      // Polymorphes Verhalten, weil als virtual deklariert

            Console.WriteLine("\n--- Basisklasse person2 = new Unterklasse()");
            Parent person2;             // Deklaration mit Basisklasse
            person2 = new Child();      // Initialisierung mit Unterklasse, nicht mit Basisklasse
            person2.WriteHello();       // Kein polymorphes Verhalten, weil nicht als virtual deklariert
            person2.WriteSeeYou();      // Polymorphes Verhalten, weil als virtual deklariert

            Console.WriteLine("\n--- Unterklasse person3 = new Unterklasse()");
            Child person3;              // Deklaration mit Unterklasse, nicht Basisklasse
            person3 = new Child();      // Initialisierung mit Unterklasse
            person3.WriteHello();       // Kein polymorphes Verhalten, weil nicht als virtual deklariert
            person3.WriteSeeYou();      // Polymorphes Verhalten, weil als virtual deklariert
        }
    }
}