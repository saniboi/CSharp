using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _03_Lambdas
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            var program = new Program();

            int beispiel = 1;
            switch (beispiel)
            {
                case 1:
                    program.DelegateNamedExample();
                    break;
                case 2:
                    program.DelegateAnonymousExample();
                    break;
                case 3:
                    program.LambdaExpressionExample();
                    break;
                case 4:
                    program.AbfrageMitLinq();
                    break;
                case 5:
                    program.AbfrageOhneLinq();
                    break;
            }
        }

        #region Delegate named (C# 1.0, 2002)

        // Deklaration

        private delegate int AddFunction(int x, int y);


        // Implementation

        private int Add(int x, int y)
        {
            return x + y;
        }


        // Verwendung

        private void DelegateNamedExample()
        {
            //AddFunction function = new AddFunction(Add); //  C# 1.0 syntax
            AddFunction function = Add;                    //  C# 2.0 syntax

            int sum = function(1, 2);
            Console.WriteLine($"Summe = {sum}");
        }

        #endregion

        #region Delegate anonymous (C# 2.0, 2005)

        // Deklaration

        private delegate int AddFunction2(int x, int y);

        private void DelegateAnonymousExample()
        {
            AddFunction2 function = delegate (int x, int y)
                                    {
                                        return x + y;       // Hinweis: Mit der Mause über "return" fahren. Vorschlag sagt "Use lambda expression"
                                    };

            int sum = function(1, 2);
            Console.WriteLine($"Summe = {sum}");
        }

        #endregion

        #region Lambda expression (C# 3.0, 2007)

        private delegate int PlusOne(int x);

        private void LambdaExpressionExample()
        {
            //PlusOne function = delegate(int x) { return x + 1; };
            //PlusOne function = (int x) => { return x + 1; };  // Schlüsselwort "delegate" weglassen, dafür "=>" hinzufügen
            //PlusOne function = (int x) => x + 1;              // Falls nur ein Ausdruck vorhanden ist, kann man das Schlüsselwort "return" und die geschweiften Klammern weglassen
            //PlusOne function = (x) => x + 1;                  // Compiler kann den Typ ableiten
            PlusOne function = x => x + 1;                      // Falls Methode nur ein Argument hat, kann man die runden Klammern weglassen
                                                                //
                                                                // Und das ist auch die Syntax, die wir bei den LINQ-Ausdrücken verwenden
                                                                // Beispiel Where-Klausel mit dem Lambda-Ausdruck innerhalb der runden Klammern:
                                                                //
                                                                //     var ergebnisliste = personenliste.Where(person => person.Alter > 18).Select(person => new {person.Alter, person.Vorname});
                                                                //
                                                                // Was es genau macht:
                                                                //
                                                                //      foreach über jedes Element der Liste und darauf Lambda ausführen, welches true oder false zurückliefert
                                                                //      Siehe Beispielcode unten.
                                                                //


            int result = function(1);
            Console.WriteLine($"Resultat = {result}");
        }

        #endregion


        #region Abfrage mit LINQ

        private void AbfrageMitLinq()
        {
            // Daten
            List<Person> personenliste = new()
            {
                new Person { Vorname = "Sara", Nachname = "Müller", Alter = 20, Wohnort = "Uster"},
                new Person { Vorname = "Peter", Nachname = "Meier", Alter = 16, Wohnort = "Zürich"},
                new Person { Vorname = "Hans", Nachname = "Muster", Alter = 21, Wohnort = "Bern" }
            };

            // Abfrage
            var personenÜber18 = personenliste.Where(person => person.Alter > 18).Select(person => new { person.Alter, person.Vorname });

            // Ausgabe
            foreach (var aktuellePerson in personenÜber18)
            {
                Console.WriteLine($"Name = {aktuellePerson.Vorname}, Alter = {aktuellePerson.Alter}");
            }
        }

        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        private class Person
        {
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public int Alter { get; set; }
            public string Wohnort { get; set; }
        }

        #endregion

        #region Abfrage mit LINQ

        private void AbfrageOhneLinq()
        {

            // Daten
            List<Person> personenliste = new()
            {
                new Person { Vorname = "Sara", Nachname = "Müller", Alter = 20, Wohnort = "Uster" },
                new Person { Vorname = "Peter", Nachname = "Meier", Alter = 16, Wohnort = "Zürich" },
                new Person { Vorname = "Hans", Nachname = "Muster", Alter = 21, Wohnort = "Bern" }
            };

            // Abfrage
            // (1/2) Erste Zwischenliste erstellen
            List<Person> personenÜber18 = new();
            foreach (Person aktuellePerson in personenliste) // personenliste.Where(person => person.Alter > 18)
            {
                if (aktuellePerson.Alter > 18)
                {
                    personenÜber18.Add(aktuellePerson);
                }
            }

            // (2/2) Zweite Liste erstellen
            // ...neue Klasse PersonMinimal erstellen
            List<PersonMinimal> personenÜber18AberNurMitMinimalenEigenschaften = new();
            foreach (Person aktuellePersonÜber18 in personenÜber18) // personenlisteÜber18.Select(person => new { person.Alter, person.Vorname });
            {
                personenÜber18AberNurMitMinimalenEigenschaften.Add(new PersonMinimal { Vorname = aktuellePersonÜber18.Vorname, Alter = aktuellePersonÜber18.Alter});
            }

            // Ausgabe
            foreach (var aktuellePerson in personenÜber18AberNurMitMinimalenEigenschaften)
            {
                Console.WriteLine($"Name = {aktuellePerson.Vorname}, Alter = {aktuellePerson.Alter}");
            }
        }

        private class PersonMinimal
        {
            public string Vorname { get; set; }
            public int Alter { get; set; }
        }
    }

    #endregion
}