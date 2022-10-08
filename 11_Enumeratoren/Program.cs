using System.Diagnostics.CodeAnalysis;

namespace _11_Enumeratoren
{
    //enum Volume { Low, Medium, High }                 // Ausserhalb der Methode deklarieren (oder besser in einer separaten Datei)
    //enum Orientation { North = 2, South, East, West } // Mit einem anderen Index beginnen


    public class Program
    {
        //enum Volume { Low, Medium, High }                 // Ausserhalb der Methode deklarieren (oder besser in einer separaten Datei)
        //enum Orientation { North = 2, South, East, West } // Mit einem anderen Index beginnen

        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    IndexDerEnumeratoren();
                    break;
                case 2:
                    SwitchMitEnumeratoren();
                    break;
                case 3:
                    BenutzereingabeInEinenEnumeratorKonvertieren_MitCasting();
                    break;
                case 4:
                    BenutzereingabeInEinenEnumeratorKonvertieren_MitEnumIsDefined();
                    break;
                case 5:
                    ÜberEinenEnumeratorIterieren();
                    break;
            }
        }

        private static void IndexDerEnumeratoren()
        {
            Console.WriteLine($"Bezeichnung: {Orientation.North}");
            Console.WriteLine($"Typ: {Orientation.North.GetType()}");
            Console.WriteLine($"Index: {(int)Orientation.North}");

            Console.WriteLine();
            Console.WriteLine($"Bezeichnung: {Volume.Medium}");
            Console.WriteLine($"Typ: {Volume.Medium.GetType()}");
            Console.WriteLine($"Index: {(int)Volume.Medium}");
        }

        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        private static void SwitchMitEnumeratoren()
        {
            Volume myVolume = Volume.Medium;
            switch (myVolume)
            {
                case Volume.Low:    // Viel sprechender mit Enum statt mit einer magischen Zahl 0.
                                    // Und sofort klar, welche Werte überhaupt möglich sind und was ihre Bedeutung ist. Selbstdokumentierend.
                    Console.WriteLine("The volume has been turned down.");
                    break;
                case Volume.Medium:
                    Console.WriteLine("The volume is in the middle.");
                    break;
                case Volume.High:
                    Console.WriteLine("The volume has been turned up.");
                    break;
            }
        }

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        private static void BenutzereingabeInEinenEnumeratorKonvertieren_MitCasting()
        {
            Console.WriteLine("Lautstärkeneinstellun:");
            Console.WriteLine("Bitte eine Auswahl treffen: (0-Leise, 1-Mittel, oder 2-Laut): ");

            string volumeString = Console.ReadLine()!;   // Wert von der Konsole als string "0", "1" oder "2" einlesen
            int volInt = int.Parse(volumeString);       // Wert in int umwandeln
                                                        // Hier fehlt noch eine Validierung, ob die Benutzereingabe wirklich im Enum existiert
                                                        // Beachte: Der Benutzer kann auch den gar nicht definierten Wert 5 eingeben und das Programm stürtzt beim Casten nicht ab
            Volume myVolume = (Volume)volInt;           // Explizite Konvertierung von int nach Volume
            switch (myVolume)                           // Entscheidung treffen Aufgrund der Benutzereingabe
            {
                case Volume.Low:
                    Console.WriteLine("Die Lautstärke ist auf Leise.");
                    break;
                case Volume.Medium:
                    Console.WriteLine("Die Lautstärke ist auf der Hälfte.");
                    break;
                case Volume.High:
                    Console.WriteLine("Die Lautstärke ist auf Laut.");
                    break;
                default:
                    Console.WriteLine("Die Benutzereingabe ist ungültig.");
                    break;
            }
        }

        /// <summary>
        /// https://stackoverflow.com/a/7996298/
        ///
        /// 
        /// Although .NET 4.0 introduced the Enum.TryParse method you should not use it for this specific scenario.
        /// In .NET an enumeration has an underlying type which can be any of the following (byte, sbyte, short, ushort, int, uint, long, or ulong).
        /// By default is int, so any value that is a valid int is also a valid enumeration value.
        /// 
        ///    This means that Enum.TryParse&lt;Animal&gt;("-1", out result) reports success even though -1 is not associated to any specified enumeration value.
        ///    As other have noted, for this scenarios, you must use Enum.IsDefined method.
        ///    Sample code (in C#):
        /// 
        /// <code>
        /// enum Test { Zero, One, Two }
        /// static void Main(string[] args)
        /// {
        ///     Test value;
        ///     bool tryParseResult = Enum.TryParse&lt;Test&gt;("-1", out value);
        ///     bool isDefinedResult = Enum.IsDefined(typeof(Test), -1);
        ///     Console.WriteLine("TryParse: {0}", tryParseResult); // True
        ///     Console.WriteLine("IsDefined: {0}", isDefinedResult); // False
        /// }
        ///</code>
        ///
        /// https://stackoverflow.com/a/29485
        /// </summary>
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        private static void BenutzereingabeInEinenEnumeratorKonvertieren_MitEnumIsDefined()
        {
            Console.WriteLine("Lautstärkeneinstellung:");
            Console.WriteLine("Bitte eine Auswahl treffen: (0-Leise, 1-Mittel, oder 2-Laut): ");
            string lautstärkeAlsString = Console.ReadLine()!;        // Integer-Wert von der Konsole als string einlesen
            int lautstärkeAlsInt = int.Parse(lautstärkeAlsString);  // Vorsicht: Wird abstürzen, wenn lautstärkeAlsString kein int ist; besser int.TryParse benutzen

            bool tryParseWarErfolgreich = Enum.TryParse(lautstärkeAlsString, out Volume lautstärkeAlsEnum);
            bool isDefinedWarErfolgreich = Enum.IsDefined(typeof(Volume), lautstärkeAlsInt);

            if (tryParseWarErfolgreich && isDefinedWarErfolgreich)
            {
                switch (lautstärkeAlsEnum)                           // Entscheidung treffen Aufgrund der Benutzereingabe
                {
                    case Volume.Low:
                        Console.WriteLine("Die Lautstärke ist auf Leise.");
                        break;
                    case Volume.Medium:
                        Console.WriteLine("Die Lautstärke ist auf der Hälfte.");
                        break;
                    case Volume.High:
                        Console.WriteLine("Die Lautstärke ist auf Laut.");
                        break;
                }
            }
            else if (!isDefinedWarErfolgreich)
            {
                Console.WriteLine($"Die Benutzereingabe {lautstärkeAlsString} ist ungültig. Gültig sind die Werte 1, 2 oder 3.");
            }
        }

        private static void ÜberEinenEnumeratorIterieren()
        {
            foreach (int value in Enum.GetValues(typeof(Volume)))
            {
                int wert = value;
                string enumBezeichnung = Enum.GetName(typeof(Volume), value)!; // Nützlich, wenn man z.B. die Bezeichungen in einem Auswahlmenü anzeigen will
                Console.WriteLine($"Volume Value: {wert} => Member: {enumBezeichnung}");
            }
        }
    }
}