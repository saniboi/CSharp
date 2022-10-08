namespace _04_Konzept_Polymorphie.Entitäten
{
    public class Produktionsmitarbeiter : Mitarbeiter
    {
        public override int BerechneLohn()
        {
            return 60;
        }
    }
}