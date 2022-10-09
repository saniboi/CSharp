using System;
using System.Diagnostics.CodeAnalysis;

namespace _01_Anonyme_Typen
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
                    AnonymerTypeZwingendMitVar();
                    break;
                case 2:
                    SindZweiAnonymeTypeWirklichVomgleichenTyp(); // Antwort: ja
                    break;
            }
        }

        private static void AnonymerTypeZwingendMitVar()
        {
            // 1. Bei anonymen Typen muss man "var" verwenden;
            //    es geht nicht anders, weil wir keinen konkreten Typennamen für die Klasse haben.
            //
            // 2. Nach dem "new" steht keine Typbezeichnung wie z.B. "new Person {...}".
            var variable = new { Menge = 108, Nachricht = "Hello"}; // Beachte: Wir mussten nicht zuerst eine Klasse definieren

            Console.WriteLine($"Menge = {variable.Menge}, Nachricht =  {variable.Nachricht}\n"); // Wir haben auch auf anonymen Typen IntelliSense-Unterstützung

            Console.WriteLine($"Typ: {variable.GetType()}");

            string s = "test";
            Console.WriteLine($"Typ: {s.GetType()} (zum Vergleichen mit obiger Typbezeichnung)\n");

            // Die Eigenschaften eines anonymen Typen sind schreibgeschützt
            //variable.Menge = 110; // Compiler-Fehler: Property or indexer 'property' cannot be assigned to -- it is read only
        }

        /// <summary>
        /// Frage eines Studierenden
        /// 
        /// Frage:   Wenn ich zwei anonyme Typen mit gleichen Eigentschaftstypen erstelle, sind die dann vom gleichen
        ///          anonymen Typ oder sind es zwei unterschiedliche anonyme Typen?
        ///
        /// Antwort: Vom gleichen Typ.
        /// </summary>
        private static void SindZweiAnonymeTypeWirklichVomgleichenTyp()
        {
            var variable1 = new { Amount = 108, Message = "Hello" };
            var variable2 = new { Amount = 108, Message = "Hello" };
            var variable3 = new { Message = "Hello", Amount = 108 }; // Hier habe ich die Reihenfolge der Eigenschaften getauscht

            Console.WriteLine($"Type von variable1: {variable1.GetType()}");
            Console.WriteLine($"Type von variable2: {variable2.GetType()}");
            Console.WriteLine($"Type von variable3: {variable3.GetType()}\n");
            Console.WriteLine($"Sind variable1 und variable2 vom gleichen (anonymen) Typ? Antwort: {variable1.GetType() == variable2.GetType()}");
            Console.WriteLine($"Sind variable1 und variable3 vom gleichen (anonymen) Typ? Antwort: {variable1.GetType() == variable3.GetType()}");
        }
    }
}