namespace _09_Klassenelemente_Methoden
{
    public class Program
    {
        public static void Main()
        {
            MethodeDeklarieren();
            MethodenMitSichtbarkeitsmodifikatoren();
        }

        #region Beispiel 1: Methoden deklarieren

        private static void MethodeDeklarieren()
        {
            var rechteck = new Rechteck(10, 12.3);
            double fläche = rechteck.BerechneFläche();          // Methodenaufruf
            Console.WriteLine($"BerechneFläche(): {fläche}");
        }

        public class Rechteck
        {
            private double seiteA, seiteB;

            public Rechteck(double seiteA, double seiteB)
            {
                this.seiteA = seiteA;
                this.seiteB = seiteB;
            }

            public double BerechneFläche()    // Von aussen aufrufbare Methode (public)
                                              // mit dem Namen BerechneFläche()
                                              // und dem Rückgabetyp double;
                                              // Empfehlung: Methodennamen sollen ein Verb in der Befehlsform enthalten  
            {
                return seiteA * seiteB;       // Mit dem Schlüsselwort return wird der Rückgabewert retourniert
            }
        }

        #endregion

        #region Beispiel 2: MethodenMitSichtbarkeitsmodifikatoren
        private static void MethodenMitSichtbarkeitsmodifikatoren()
        {
            var meineKlasse = new KlasseMitMethodenMitUnterschiedlichenSichtbarkeitsmodifikatoren();
            meineKlasse.PublicMethod();     // Sichtbar; wird daher auch in IntelliSense angezeigt
            //meineKlasse.PrivateMethod();  // Nicht sichtbar und daher auch nicht aufrufbar
        }

        // Falls vor der Klasse kein Sichtbarkeitsmodifikator steht, ist der Standard "internal"
        // Daumenregel 1: Der Lesbarkeit und Klarheit halber immer explizit ausschreiben
        // Daumenregel 2: Immer die strikteste Sichtbarkeit einstellen, denn die Sichtbarkeit ausweiten
        //                ist immer möglich ohne Code von anderen zu beeinträchtigen; die Sichtbarkeit
        //                einschränken bedeutet immer potentiell Code von anderen Benutzer brechen ("breaking change", Major-Version hochzählen)
        public class KlasseMitMethodenMitUnterschiedlichenSichtbarkeitsmodifikatoren
        {
            public string PublicMethod()
            {
                return "Antwort von öffentlicher Methode.";
            }

            private string PrivateMethod()
            {
                return "Antwort von privater Methode";
            }

            private void AndereMethode()
            {
                PrivateMethod(); // Die private Methode kann von innerhalb der Klasse aufgerufen werden
            }
        }
        #endregion
    }
}