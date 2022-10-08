using System.Diagnostics.CodeAnalysis;

namespace _14_Klassenelemente_Statischer_Konstruktor
{
    [SuppressMessage("ReSharper", "UnusedVariable")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class Program
    {
        static void Main()
        {
            //KonstruktoraufrufeBeiStatischemZugriff();

            // Zur Illustration ein Klassendiagramm aufzeichnen:
            //
            // Program → KlasseMitStatischemKonstruktor → Klasse1
            //                                       \--→ Klasse2
            //
            // Pauschal gesagt: Es werden zuerste alle statischen Methoden ausgeführt.
            //                  Danach werden alle Instanzmethoden ausgeführt.
            //
            KonstruktoraufrufeBeiNichtStatischemZugriff();
        }

        private static void KonstruktoraufrufeBeiStatischemZugriff()
        {
            // Vor dem ersten Zugriff ein statisches Attribut wird der
            // statische Konstruktor zur potentiellen Initialisierung
            // der statischen Attribute aufgerufen
            Console.WriteLine(KlasseMitStatischemKonstruktor.StatischesAttribut);
        }

        private static void KonstruktoraufrufeBeiNichtStatischemZugriff()
        {
            // Alle Konstruktoren und Destruktoren werden ausgeführt
            var klasseMitStatischemKonstruktor = new KlasseMitStatischemKonstruktor();
        }
    }
}