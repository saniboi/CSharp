using Übung_3_3_Geometrische_Formen.Formen;

namespace Übung_3_3_Geometrische_Formen
{
    public class FormenFabrik
    {
        public static IForm[] ErstelleEineListeVonUnterschiedlichenFormen()
        {
            IForm[] geometrischeFormenListe = new IForm[]
            {
                new Kreis(3),
                new Kreis(4),
                new Quadrat(4)
            };

            return geometrischeFormenListe;
        }
    }
}