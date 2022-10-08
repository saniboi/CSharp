//using AutoZubehoerIPS;                          // Normales using (wie gehabt)
//using MeinAlias = AutoZubehoerIPS;              // Alias für einen Namensraum
//using MeinSpoiler = AutoZubehoerIPS.Spoiler;    // Alias für eine Klasse

namespace _05_Namensräume
{
    public class Program
    {
        public static void Main()
        {
            AutoZubehoerIPS.Spoiler spoilerA; // Verwendet man oben das using, kann der vordere Teil "AutoZubehoerIPS" weggelassen werden
            AutoZubehoerRemus.Spoiler spoilerB;
        }
    }
}

namespace AutoZubehoerIPS   // Normalerweise erstellt man für einen neuen Namensraum eine neue Assembly
{
    public class Spoiler    // Normalerweise erstellt man für Klassen eine neue Datei
    {
        // Leer
    }
}

namespace AutoZubehoerRemus
{
    public class Spoiler
    {
        // Leer
    }
}

// Verschachtelte Namensräume
namespace Microsoft
{
    namespace Office
    {
    }
}

// Verschachtelte Namensräume in der Kurzschreibweise
namespace Microsoft2.Office2
{
}