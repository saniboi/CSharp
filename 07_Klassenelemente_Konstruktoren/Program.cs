using System.Diagnostics.CodeAnalysis;

namespace _07_Klassenelemente_Konstruktoren
{
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    [SuppressMessage("ReSharper", "NotAccessedVariable")]
    [SuppressMessage("ReSharper", "RedundantAssignment")]
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 4;
            switch (beispiel)
            {
                case 1:
                    Konstruktor();
                    break;
                case 2:
                    KonstruktorMitParameter();
                    break;
                case 3:
                    PrivaterKonstruktor();
                    break;
                case 4:
                    Destruktor();
                    break;
            }
        }

        #region Beispiel 1: Konstruktor
        public static void Konstruktor()
        {
            new Mitarbeiter(); // Speicher für eine Mitarbeiter-Klasse wird alloziert und
                               // der Konstruktor wird ausgeführt
        }

        public class Mitarbeiter
        {
            public Mitarbeiter() // Der Konstruktor muss gleich heissen wie die Klasse,
                                 // hat aber runde Klammern wie eine reguläre Methode und
                                 // kein void und dergleichen.
                                 // Schreiben wir keinen Konstruktor, wird automatisch ein
                                 // leerer Standardkonstruktor generiert.
            {
                Console.WriteLine("Konstruktor: eine Instanz der Klasse Mitarbeiter wurde erzeugt!");
            }
        }
        #endregion

        #region Beispiel 2: Konstruktor mit Parametern
        public static void KonstruktorMitParameter()
        {
            var ma = new MitarbeiterMitKonstruktorMitParametern("Hans", "Muster");
            Console.WriteLine(ma.Vorname);
            Console.WriteLine(ma.Nachname);
        }

        public class MitarbeiterMitKonstruktorMitParametern
        {
            public string Nachname; // Public Felder sollte man nicht benutzen, sondern wenn schon Eigenschaften.
                                    // Hier wird public verwendet, damit das Beispiel kompakt bleibt.
            public string Vorname;

            public MitarbeiterMitKonstruktorMitParametern(string vorname, string nachname)
            {
                Vorname = vorname;
                Nachname = nachname;
            }
        }
        #endregion

        #region Beispiel 3: Privater Konstruktor
        public static void PrivaterKonstruktor()
        {
            // Diese Klasse kann nicht instanziiert werden, weil der Konstruktor als privat deklariert ist.
            // Das ist sinvoll z.B. bei Funktionssammlungen wie einer Klasse der Art von Math
            // (aber in diesem konkreten Fall ist der Konstruktor der Math-Klasse nicht private).

            //new MitarbeiterMitPrivatemKonstruktor();
        }

        public class MitarbeiterMitPrivatemKonstruktor
        {
            private MitarbeiterMitPrivatemKonstruktor()
            {
                // Leer
            }
        }
        #endregion

        #region Beispiel 4: Destruktor
        private static void Destruktor()
        {
            var meineInstanz = new MitarbeiterMitDesktruktor();
            meineInstanz = null; // Hier sollte/könnte der Desktruktor aufgerufen werden.
            GC.Collect();        // Hier sollte/müsste der Destruktor aufgerufen werden.
            // Es kann auch sein, dass er Destruktor gar nie aufgerufen wird
            // https://www.pluralsight.com/guides/destructors-uncertainty-of-destructive
        }

        public class MitarbeiterMitDesktruktor
        {
            public MitarbeiterMitDesktruktor()
            {
                Console.WriteLine("Der Konstruktor wurde aufgerufen.");
            }

            /// <summary>
            /// Destruktoren sieht man fast nie selten, weil man keine Garantie hat, wann und ob sie überhaupt
            /// aufgerufen werden.
            /// 
            /// Daher wird fast immer das IDisposable-Inferface und die Methode Dispose() verwendet,
            /// welche wir später kennenlernen werden. Siehe Beispiel 11_Klassenelemente_Destruktor und 24_Interfaces_IDisposable.
            /// </summary>      
            ~MitarbeiterMitDesktruktor()
            {
                Console.WriteLine("Der Destruktor wurde aufgerufen.");
            }
        }
        #endregion
    }
}