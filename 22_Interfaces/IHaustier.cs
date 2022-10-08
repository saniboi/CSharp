namespace _22_Interfaces
{
    public interface IHaustier
    {
        /*public*/
        string MachGeräusch();   // Vor C# 8 (2019) könnte man den Sichtbarkeitsmodifikator "public"
        // nicht hinschreiben (Kompilerfehler);

        /*public*/
        string Name { get; set; }
    }
}