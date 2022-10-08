using _04_Konzept_Polymorphie._01_Vorher;
using _04_Konzept_Polymorphie._02_Nachher;

namespace _04_Konzept_Polymorphie
{
    public class Program
    {
        public static void Main()
        {
            new OhnePolymorphie().LasseBeispielLaufen();
            new MitPolymorphie().LasseBeispielLaufen();
        }
    }
}