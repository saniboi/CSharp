namespace Übung_6_2_Mitarbeiterverzeichnis_mit_generischem_Hastable
{
    public class Mitarbeiter
    {
        public int Personalnummer { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Telefonnummer { get; set; }
        public string Firma { get; set; }

        public override string ToString()
        {
            return string.Format($"Personalnummer: {Personalnummer}, Vorname: {Vorname}, Nachname: {Nachname}, Telefonnummer {Telefonnummer}");
        }
    }
}