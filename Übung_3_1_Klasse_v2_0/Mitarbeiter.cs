using System;

namespace Übung_3_1_Klasse_v2_0
{
    internal class Mitarbeiter
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Personalnummer { get; set; }
        public DateTime Eintrittsdatum { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public double Salaer { get; set; } // decimal wäre auch ein geeigneter Datentyp gewesen
        public string PrivateAdresse { get; set; }
        /// <summary>
        /// string, weil damit möglich ist, vorangehende Nullen
        /// abzubilden; z.B. mit int wäre das nicht möglich
        /// </summary>
        public string Telefonnummer { get; set; }
    }
}