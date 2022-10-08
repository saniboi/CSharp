namespace _08_Klassenelemente_Partielle_Klassen
{
    public partial class Auto
    {
        public string MethodeAusPartialClassAuto1()
        {
            return "partial 1";
        }

        // Wie in einer normalen nicht-partiellen Klasse kann man auch bei partiellen Klassen
        // nicht zwei Methoden mit dem gleichen Namen haben
        //public string MethodeAusPartialClassAuto2()
        //{
        //    return "partial x";
        //}
    }
}