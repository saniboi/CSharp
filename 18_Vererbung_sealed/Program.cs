namespace _18_Vererbung_sealed
{
    public class Program
    {
        public static void Main()
        {
            // Nichts
        }
    }

    /// <summary>
    /// Die Klasse ist als sealed markiert;
    /// daher ist es nicht möglich von ihr zu erben.
    /// </summary>
    public sealed class MeineSealedKlasse
    {
        // Nichts
    }

    public class MeineAndereKlasse //: MeineSealedKlasse // Geht nicht, da MeineSealedKlasse als sealed markiert ist
    {
        // Nichts
    }
}