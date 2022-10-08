using System;
using System.Diagnostics.CodeAnalysis;

namespace WozuNullCheckBeiConsoleReadLine
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    BeispielMitAbsturzMöglichkeit();
                    break;
                case 2:
                    BeispielOhneAbsturzMöglichkeit();
                    break;
            }
        }

        private static void BeispielMitAbsturzMöglichkeit()
        {
            // Frage: Warum sagt Visual Studio, dass man bei Console.ReadLine() einen Null-Check machen muss?

            Console.Write("Bitte einen Text eingeben und Enter drücken oder Ctrl+Z drücken und Enter: ");
            string benutzereingabe = Console.ReadLine();

            Console.WriteLine($"Die Benutzereingabe war '{benutzereingabe}' und hat eine Länge von '{benutzereingabe.Length}'"); // Siehe Warnung bei benutzereingabe.Length: Possible System.NullReferenceException

            // Antwort: Weil Console.ReadLine() gemäss Vertrag in der Tat ein Null zurückgeben kann. Siehe Methodenkommentar von ReadLine().
            //          Wenn der Benutzer z.B. Ctrl+Z eingibt, kommt Null zurück.

            // Quelle: https://stackoverflow.com/questions/38370565/resharper-says-that-console-readline-returns-null-value
        }

        private static void BeispielOhneAbsturzMöglichkeit()
        {
            // Es gibt verschiedene Möglichkeit, wie man robusten (absturzsicheren) Code schreiben kann
            // Möglichkeiten 1 und 3 geben kompakten Code
            // Möglichkeiten 2 und 4 blähen den Code auf

            // Möglichkeit 1: Beim Einlesen im Null-Fall einen leeren String in die Variable schreiben
            // Vorteil: kompakter Code
            // Nachteil: In der Variablen "benutzereingabe" steht jetzt ein leerer String. Sich fragen, ob wir das wirklich so wollen und was das für den Rest des Programmablaufs bedeutet.
            Console.Write("1) Bitte einen Text eingeben und Enter drücken oder Ctrl+Z drücken und Enter: ");
            string benutzereingabe = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Die Benutzereingabe war '{benutzereingabe}' und hat eine Länge von '{benutzereingabe.Length}'"); // Beachte: Hier kommt keine Warnung mehr für "Possible System.NullReferenceException"

            // Möglichkeit 2: Vor jedem Zugriff auf die Variable auf Null prüfen
            Console.Write("2) Bitte einen Text eingeben und Enter drücken oder Ctrl+Z drücken und Enter: ");
            benutzereingabe = Console.ReadLine();
            if (benutzereingabe != null)
            {
                Console.WriteLine($"Die Benutzereingabe war '{benutzereingabe}' und hat eine Länge von '{benutzereingabe.Length}'"); // Beachte: Hier kommt keine Warnung mehr für "Possible System.NullReferenceException"
            }

            // Möglichkeit 3: Beim Ausgeben mit dem Fragezeichen-?-Operator null-safe auf die Variable zugreifen
            Console.Write("3) Bitte einen Text eingeben und Enter drücken oder Ctrl+Z drücken und Enter: ");
            benutzereingabe = Console.ReadLine();
            Console.WriteLine($"Die Benutzereingabe war '{benutzereingabe}' und hat eine Länge von '{benutzereingabe?.Length}'"); // Beachte: Hier kommt keine Warnung mehr für "Possible System.NullReferenceException"

            // Möglichkeit 4: Kritische Variablenzugriffe mit try-catch schützen
            // Nachteil: Da try-catch für Aussnahmefälle gedacht ist und der Null-Fall für "benutzereingabe" ein ganz normaler, erwarteter Fall ist, ist das nicht die beste Lösung
            Console.Write("4) Bitte einen Text eingeben und Enter drücken oder Ctrl+Z drücken und Enter: ");
            benutzereingabe = Console.ReadLine();
            try
            {
                Console.WriteLine($"Die Benutzereingabe war '{benutzereingabe}' und hat eine Länge von '{benutzereingabe.Length}'"); // Beachte: Hier _mit _Warnung für "Possible System.NullReferenceException"
            }
            catch (NullReferenceException c)
            {
                Console.WriteLine($"Die Variable {nameof(benutzereingabe)} ist Null, sollte sie aber nicht sein. Der Benutzer sollte einen Text eingeben.");
                Console.WriteLine(c);
                throw;
            }
        }
    }
}
