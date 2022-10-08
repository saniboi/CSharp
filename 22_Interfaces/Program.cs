using System.Diagnostics.CodeAnalysis;

namespace _22_Interfaces
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;

            Program program = new Program();
            switch (beispiel)
            {
                case 1:
                    program.ShowUsageOfInterfaces();
                    break;
                case 2:
                    program.CastingExample();
                    break;
            }
        }

        // Der Code in dieser Klasse muss nicht mehr angepasst werden,
        // weil er mit allen Arten von Haustieren umgehen kann.
        private void ShowUsageOfInterfaces()
        {
            Console.WriteLine("--- ShowUsageOfInterfaces() ---");

            IHaustier[] haustiere = HaustierFabrik.HoleHaustierListe(); // Die Haustierfabrik kann alle Arten von
                                                                        // Tieren zurückliefern, die IHaustier implementieren
            Console.WriteLine($"{haustiere[0].Name} macht: {haustiere[0].MachGeräusch()}");

            foreach (IHaustier tier in haustiere)
            {
                // http://stackoverflow.com/questions/1159906/finding-the-concrete-type-behind-an-interface-instance
                Console.WriteLine($"{tier.Name} (Typ: {tier.GetType()}) macht {tier.MachGeräusch()}");
            }

            Console.WriteLine();
        }

        private void CastingExample()
        {
            Console.WriteLine("--- CastingExample() ---");

            IHaustier haustier = new Hund { Name = "Bello" };
            Console.WriteLine(haustier.GetType());
            Hund hund = haustier as Hund; // Gibt null zurück, falls Konvertierung fehlschlägt
            //Hund hundhaustier = (Hund)haustier; // Wirft Exception, falls Konvertierung fehlschlägt
            Console.WriteLine(hund.Name);
        }
    }
}