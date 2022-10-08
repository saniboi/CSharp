namespace _22_Interfaces
{
    public class Hund : IHaustier
    {
        public string Name { get; set; }

        public string MachGeräusch()
        {
            return "Wuff";
        }
    }
}