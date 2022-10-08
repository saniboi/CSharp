namespace _17_Vererbung_base.Entitäten
{
    public class Person
    {
        public string Vorname { get; }
        public string Nachname { get; set; }

        public Person(string vorname)
        {
            Vorname = vorname;
        }

        public Person(string vorname, string nachname)
        {
            Vorname = vorname;
            Nachname = nachname;
        }
    }
}