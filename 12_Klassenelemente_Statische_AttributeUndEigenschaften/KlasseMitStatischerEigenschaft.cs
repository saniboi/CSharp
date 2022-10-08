namespace _12_Klassenelemente_Statische_AttributeUndEigenschaften
{
    public class KlasseMitStatischerEigenschaft
    {
        public static int StatischeEigenschaft { get; set; }
        public int NichtStatischeEigenschaft { get; set; }

        public int GibStatischeEigenschaftAus()
        {
            return StatischeEigenschaft;
        }
    }
}