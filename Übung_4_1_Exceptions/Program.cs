using System;
using System.Diagnostics.CodeAnalysis;
#pragma warning disable 168

namespace Übung_4_1_Exceptions
{
    public class Program
    {
        public static void Main()
        {
            Run();
        }

        [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
        private static void Run()
        {
            var person1 = new Person { Vorname = "Hans", Nachname = "Müller", Stadt = "Zürich" };
            var person2 = new Person { Vorname = "Peter", Nachname = "Meier", Stadt = "Bern" };
            var person3 = new Person { Vorname = "Sara", Nachname = "Muster", Stadt = "Uster" };

            // Funktioniert
            Console.WriteLine("--- Erfolgreicher Fall ---");
            person1.CompareTo(person2);

            // Funktioniert nicht, wirft Exception
            Console.WriteLine("\n--- Fehlerfall ---");
            var irgendEinObjektDasNichtVomTypPersonIst = new DateTime();
            try
            {
                person1.CompareTo(irgendEinObjektDasNichtVomTypPersonIst);
            }
            catch (ArgumentException exception)
            {
                // Hier irgend etwas unternehmen, um die Fehlersituation zu bereinigen oder zu loggen
                Type erwarteterTyp = typeof(Person);
                Type tatsächlicherTyp = irgendEinObjektDasNichtVomTypPersonIst.GetType();
                Console.WriteLine($"Das Argument {nameof(irgendEinObjektDasNichtVomTypPersonIst)} war vom Typ {tatsächlicherTyp}, statt wie erwartet vom Typ {erwarteterTyp}.");
                //Console.WriteLine(exception.StackTrace);
            }

            // Teilaufgabe 3
            Console.WriteLine("\n--- Personenliste sortieren ---");
            Person[] personenliste = { person1, person2, person3 };
            Array.Sort(personenliste);      // Beachte in der Konsolenausgabe, dass unsere selbstimplementierte CompareTo-Methode dreimal aufgerufen wurde
            foreach (Person aktuellePerson in personenliste)
            {
                Console.WriteLine(aktuellePerson);
            }
        }
    }
}