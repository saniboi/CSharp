using Übung_3_3_Geometrische_Formen.Formen;

namespace Übung_3_3_Geometrische_Formen
{
    public class Program
    {
        public static void Main()
        {
            IForm[] testDaten = FormenFabrik.ErstelleEineListeVonUnterschiedlichenFormen();

            var testTreiber = new TestTreiber(testDaten);
            testTreiber.DruckeDieListeDerFormen();
        }
    }
}