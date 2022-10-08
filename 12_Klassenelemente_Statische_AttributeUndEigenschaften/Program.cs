using System.Diagnostics.CodeAnalysis;

namespace _12_Klassenelemente_Statische_AttributeUndEigenschaften
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public static void Main()
        {
            var p = new Program();
        }

        public Program()
        {
            var objekt1 = new KlasseMitStatischerEigenschaft();
            var objekt2 = new KlasseMitStatischerEigenschaft();

            // Nicht-statische Eigenschaften hat jede Klasse für sich alleine.
            // Darum werden sie auch Instanzvariablen genannt.
            objekt1.NichtStatischeEigenschaft = 1;
            objekt2.NichtStatischeEigenschaft = 2;
            Console.WriteLine($"objekt1.NichtStatischeEigenschaft = {objekt1.NichtStatischeEigenschaft}");
            Console.WriteLine($"objekt2.NichtStatischeEigenschaft = {objekt2.NichtStatischeEigenschaft}");

            // Statische Eigenschaften werden zwischen allen Instanzen einer Klasse geteilt.
            // Das Ändern auf einer Instanz wirkt sich auf alle anderen Instanzen aus.
            // Konstanten sind Kandidaten, die man static machen könnte.

            // objekt1.StatischeEigenschaft = 1; // Zugriff via Instanzname geht nicht

            // Zugriff geht via Klassenname. Das Ändern hier führt dazu, dass
            // sowohl bei objekt1 als auch bei objekt2 sich der Wert ändert.
            KlasseMitStatischerEigenschaft.StatischeEigenschaft = 3;
            Console.WriteLine($"objekt1.StatischeEigenschaft = {objekt1.GibStatischeEigenschaftAus()}");
            Console.WriteLine($"objekt2.StatischeEigenschaft = {objekt2.GibStatischeEigenschaftAus()}");
        }
    }
}