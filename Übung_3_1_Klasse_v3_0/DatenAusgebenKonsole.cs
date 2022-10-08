using System;

namespace Übung_3_1_Klasse_v3_0
{
    public class DatenAusgebenKonsole
    {
        public void GibAus(Mitarbeiter mitarbeiter)
        {
            Console.Clear();
            Console.WriteLine($"Vorname: {mitarbeiter.Vorname}");
            Console.WriteLine($"Nachname: {mitarbeiter.Nachname}");
            Console.WriteLine($"Personalnummer: {mitarbeiter.Personalnummer}");
            Console.WriteLine($"Eintrittsdatum: {mitarbeiter.Eintrittsdatum.ToShortDateString()}"); //ToShort, damit der Wert für die Zeit (00:00:00) nicht ausgegeben wird
            Console.WriteLine($"Geburtsdatum: {mitarbeiter.Geburtsdatum.ToShortDateString()}");
            Console.WriteLine($"Salär: {mitarbeiter.Salaer}");
            Console.WriteLine($"Adresse: {mitarbeiter.PrivateAdresse}");
            Console.WriteLine($"Telefonnummer: 0041{mitarbeiter.Telefonnummer}");
        }
    }
}
