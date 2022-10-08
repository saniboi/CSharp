namespace _04_Konzept_Polymorphie.Entitäten
{
    public class Mitarbeiter
    {
        public string Name { get; set; }

        public virtual int BerechneLohn()
        {
            return 0;
        }
    }
}