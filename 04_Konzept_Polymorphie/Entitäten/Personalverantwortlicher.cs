namespace _04_Konzept_Polymorphie.Entitäten
{
    public class Personalverantwortlicher : Mitarbeiter
    {
        public override int BerechneLohn()
        {
            return 70;
        }
    }
}