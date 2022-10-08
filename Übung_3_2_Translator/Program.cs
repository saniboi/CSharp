using System.Diagnostics.CodeAnalysis;
using Übung_3_2_Translator.Beispiele;

namespace Übung_3_2_Translator
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 3;

            switch (beispiel)
            {
                case 1:
                    new Beispiel1MinimaleVersion().Starte();
                    break;
                case 2:
                    new Beispiel2VolleVersion().Starte();
                    break;
                case 3:
                    new Beispiel3VolleVersionMitFabrikmuster().Starte();
                    break;
            }
        }
    }
}