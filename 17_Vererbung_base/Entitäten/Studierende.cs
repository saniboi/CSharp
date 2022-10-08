namespace _17_Vererbung_base.Entitäten
{
    public class Studierende : Person
    {
        public Studierende(string vorname) : base(vorname)
        {
            // Hier gibt es nichts mehr zu tun.
            // Der Aufruf von base initialisiert alles nötige.
        }


        public Studierende(string vorname, string nachname) : base(vorname, nachname)
        {
            // Hier gibt es nichts mehr zu tun.
            // Der Aufruf von base initialisiert alles nötige.
        }

        

        // Ohne das base(vorname), müsste man hier etwas in dieser Art implementieren
        //public Studierende(string vorname)
        //{
        //    base.Vorname = vorname;
        //}
    }
}