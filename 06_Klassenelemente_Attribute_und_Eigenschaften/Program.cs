using System.Diagnostics.CodeAnalysis;
#pragma warning disable 169

namespace _06_Klassenelemente_Attribute_und_Eigenschaften
{
    public class Program
    {
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public static void Main()
        {
            new MitarbeiterMitAttributen();                     // Klassendefinition anschauen
            new MitarbeiterMitSchreibgeschützenAttributen();    // Klassendefinition anschauen
            new MitarbeiterMitEigenschaft();                    // Klassendefinition anschauen
            new MitarbeiterMitSchreibgeschützterEigenschaft();  // Klassendefinition anschauen
        }
    }

    public class MitarbeiterMitAttributen
    {
        public string Name = null!; // Das ist ein Attribut; oder auch Feld genannt
                            // Empfehlung: möglichst keine public Felder verwenden, sondern public Eigenschaften
        private Abteilung abteilung = null!;
        private int batchNr;
    }

    public class Abteilung
    {
        // Leer
    }

    [SuppressMessage("ReSharper", "MemberInitializerValueIgnored")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class MitarbeiterMitSchreibgeschützenAttributen
    {
        public readonly string Firma = "Software Factory"; // Falls Visual Studio sagt
                                                           // "Field initializer value ignored during initialization"
                                                           // dann liegt es daran, dass "Firma" im Konstruktor nochmals
                                                           // gesetzt wird und somit der Wert hier "Software Factory"
                                                           // nie verwendet wird.
                                                           // Im Konstruktor Kommentarzeichen hinzufügen und dann
                                                           // verschwindet auch die Meldung.

        // Konstruktor
        public MitarbeiterMitSchreibgeschützenAttributen()
        {
            Firma = "Anderer Wert"; // Im Konstruktur kann ein readonly-Attribut gesetzt werden
        }

        public void EineMethode()
        {
            //Firma = "geht nicht"; // In einer Methode kann ein readonly-Attribut nicht verändert werden
            //                      // Siehe Compiler-Fehlermeldung
        }

        // Unterschiede zu Konstanten
        public const int MeineKonstante = 10;
        //public static void Main()
        //{
        //    int i = MitarbeiterMitSchreibgeschützenAttributen.MeineKonstante; // Zugriff bei Konstanten via Klassenname ohne new-Schlüsselwort

        //    var ma = new MitarbeiterMitSchreibgeschützenAttributen();
        //    string s = ma.Firma; // Zugriff bei readonly-Attributen via Objektreferenz
        //}
    }

    public class MitarbeiterMitEigenschaft
    {
        // Ausgeschriebene Variante
        // Diese Variante wird verwendet, wenn man im Getter und Setter zusätzlichen Code schreiben will
        // oder Lese- oder Schreib-geschützte Eigenschaften haben will (kommt weiter unten)
        // Daumenregel: in Getter und Setter sollte man keine rechenintensiven Operationen verstauen
        private string name = null!;    // Variable mit Kleinbuchstaben beginnen, gemäss Namenskonvention für lokale Variablen
        public string Name      // Variable mit Grossbuchstaben beginnen, gemäss Namenskonvention für lokale Variablen
        {
            get { return name; }
            set { name = value; }
        }

        // Auto-property-Variante
        public string Name2 { get; set; } = null!; // Ist equivalent zum obigen Code, sofern im Getter und Setter
                                          // kein zusätzlicher Code hinzugefügt wurde
                                          // Das set kann man weglassen, um eine schreibgeschützte Eigenschaft zu erhalten
                                          // Das get kann man nicht weglassen in dieser Auto-property-Schreibweise
    }

    public class MitarbeiterMitSchreibgeschützterEigenschaft // Ein Anwendungsfall: ich will eine Klasse, die von aussen nicht verändert werden kann
    {
        private string name; // Variable mit Kleinbuchstaben beginnen gemäss Namenskonvention für lokale Variablen
        public string Name   // Variable mit Grossbuchstaben beginnen gemäss Namenskonvention für lokale Variablen
        {
            get { return name; }
            // Das set wurde gelöscht => schreiben der Variable von aussen nicht möglich => Schreibgeschützte Eigenschaft
        }

        public MitarbeiterMitSchreibgeschützterEigenschaft()
        {
            name = "Initialisierung"; // Von innerhalb der Klasse, kann das Feld gesetzt werden
                                      // Von ausserhalb nicht, weil das Feld private ist (kommt später unter Sichtbarkeitsmodifikatoren)
        }

        //public static void Main()
        //{
        //    var ma = new MitarbeiterMitSchreibgeschützterEigenschaft();
        //    string name = ma.Name; // Das Lesen funktioniert
        //    //ma.Name = "Wert setzen"; // Das Schreiben geht nicht, weil Name schreibgeschützt ist
        //}
    }

    // Die Design-Guidelines raten davon ab, dieses Konstrukt zu verwenden:
    // http://stackoverflow.com/questions/9535747/is-there-any-reason-to-have-a-property-with-no-getter
    public class MitarbeiterMitLesegeschützterEigenschaft
    {
        private string name = null!;
        public string Name
        {
            // Das get wurde gelöscht => Lesen der Variable von aussen nicht möglich => Lesegschützte Eigenschaft
            set { name = value; }
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void MeineMethode()
        {
            string derName = name; // Das Lesen von innerhalb der Klasse geht
        }

        //public static void Main()
        //{
        //    var ma = new MitarbeiterMitLesegeschützterEigenschaft();
        //    ma.Name = "Wert setzen"; // Das Schreiben geht
        //    //string name = ma.Name; // Das Lesen geht nicht, weil Name lesegschützt ist
        //}
    }
}