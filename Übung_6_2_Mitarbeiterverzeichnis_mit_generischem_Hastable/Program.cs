namespace Übung_6_2_Mitarbeiterverzeichnis_mit_generischem_Hastable
{
    public class Program
    {
        public static void Main()
        {
            var testtreiber = new Testtreiber();
            testtreiber.MitarbeiterverzeichnisInstanziieren();
            testtreiber.EinPaarMitarbeiterInsVerzeichnisAufnehmen();
            testtreiber.AbfragenÜberDiePersonalnummerAusführen();                   // Personalnummer ist der Schlüssel (key)
            testtreiber.WasGeschietBeiEinerAbfrageWoDerSchlüsselNichtExistiert();   // Spezialfall
            testtreiber.AbfragenÜberMitareitervornamenAusführen();                  // Vorname ist ein Teil des Wertes (value)
        }
    }
}