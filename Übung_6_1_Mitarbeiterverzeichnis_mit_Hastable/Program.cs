namespace Übung_6_1_Mitarbeiterverzeichnis_mit_Hastable
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