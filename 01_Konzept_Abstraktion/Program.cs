namespace _01_Konzept_Abstraktion
{
    public class Program
    {
        public static void Main()
        {
            // Objekt, Instanz
            Person peter = new Person();  // Seit C# 1.0 (2002)
            //var peter = new Person();   // Oder so mit "var type inference" seit C# 3.0 (2007)
            //Person peter = new();       // Oder so mit "target-typed 'new' expressions" seit C# 9 (2020)

            peter.Vorname = "Peter";
            peter.Nachname = "Müller";

            // Initialisierungssyntax
            Person hans = new Person
            {
                // Initialisierungsyntax, womit man Eigenschaften direkt bei der Instanziierung
                // setzen kann; analog wie Initialisierungsyntax bei Datenfeldern;
                // Beispiel int[] oneDimensionalArray5 = { 1, 2, 3 };
                Vorname = "Hans",
                Nachname = "Muster"
            };

            // Objekt, Instanz
            Person sara = new Person { Vorname = "Sara", Nachname = "Meier" };

            Console.WriteLine($"Vorname: {hans.Vorname}");
            Console.WriteLine($"Nachname: {hans.Nachname}");
            Console.WriteLine($"Vorname: {sara.Vorname}");
            Console.WriteLine($"Nachname: {sara.Nachname}");

            // Komplexitätsreduktion
            // In einem ersten Schritt kann man sich abstrakt über "Personen" unterhalten.
            // In einem zweiten Schritt kann man sich konkret über die die Objekte "hans" und "sara" unterhalten.

            // In einer Welt ohne OOP und Abstraktion → Siehe unten oder nächstes Beispiel 02_Konzept_Kapselung
            // - Alles Wertetypen (das nennt man auch den "Primitive obsession"-Smell)
            // - Kein IntelliSense
            // - Keine Abstraktion
            // - Höhere Komplexität
            //string hansVorname = "Hans";
            //string saraVorname = "Sara";
            //string hansNachname = "Muster";
            //string saraNachname = "Meier";
            //int hansAlter = 25;
            //int saraAlter = 30;
        }
    }

    // Klasse, Abstraktion, Vorlage, Prägestempel
    public class Person // Konvention ist es für jede Klasse eine eigene Datei zu verwenden.
                        // Hier schreibe ich es in die gleiche Klasse, weil es am Bildschirm
                        // einfacher zu sehen ist.
    {
        public string Vorname { get; set; } = null!;
        public string Nachname { get; set; } = null!;
    }
}