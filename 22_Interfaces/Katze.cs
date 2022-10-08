namespace _22_Interfaces
{
    public class Katze : IHaustier
    {
        public string Name { get; set; }

        public string MachGeräusch()
        {
            return "Miau";
        }
    }
}