namespace _04_Konzept_Polymorphie.Entitäten
{
    public class Chef : Mitarbeiter
    {
        public override int BerechneLohn()
        {
            return 70;
        }
    }
}