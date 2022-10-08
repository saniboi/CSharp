namespace _02_Konzept_Kapselung
{
    public class Program
    {
        public static void Main()
        {
            // Ohne Kapselung wird der Code rasch unübersichtlich und damit schwierig wartbar
            string vorname1 = "Hans";
            string nachname1 = "Muster";
            string vorname2 = "Sara";
            string nachname2 = "Meier";
            Console.WriteLine($"Person: {vorname1} {nachname1}");
            Console.WriteLine($"Person: {vorname2} {nachname2}");
            Console.WriteLine();

            // Mit Kapselung wird der Code übersichtlich, leserlich und damit leichter wartbar
            Person hans = new Person { Vorname = "Hans", Nachname = "Muster" };
            Person sara = new Person { Vorname = "Sara", Nachname = "Meier" };
            Console.WriteLine(hans.ToString()); // Die Logik für ToString() ist in der Klasse Person gekapselt;
                                                // dort wo sie logisch auch hingehört.

            Console.WriteLine(sara);            // Gleichbedeutend wie mit ToString(), weil WriteLine das ToString() aufruft

            // Komplexitätsreduktion
            // Wenn man im Visual Studio "hans." eingibt, sieht man
            // a) alles, was man mit einem Objekt vom Typ "Person" machen kann und
            // b) eben nur genau das und nicht mehr (= Komplexitätsreduktion) und
            // c) all das geht ohne die Implementierungsdetails (Datentypen, Algorithmen usw.)
            //    kennen zu müssen (= Komplexitätsreduktion).
        }

        // Alles, was zu einer Person gehört, ist hier gekapselt und isoliert
        public class Person
        {
            public string Vorname { get; set; } = null!;
            public string Nachname { get; set; } = null!;

            public override string ToString() // Diese Methode löschen und schauen, wie der Output dann aussieht.
            {
                // Wenn ich die ToString()-Ausgabe
                // später anpassen will, kann ich das
                // hier ein einem Ort machen und die
                // Anpassung wird sofort für alle Objekte
                // vom Typ Person gültig.

                return $"Person: {Vorname} {Nachname}";
            }
        }
    }
}