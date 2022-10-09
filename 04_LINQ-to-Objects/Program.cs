using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _04_LINQ_to_Objects
{
    /// <summary>
    /// Query keywords: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/query-keywords
    /// Enumerable:     https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=net-6.0
    /// Queryable:      https://docs.microsoft.com/en-us/dotnet/api/system.linq.queryable?view=net-6.0
    ///
    /// Tutorial:       https://www.tutorialsteacher.com/linq
    /// Konzept:        https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
    /// Beispiele:      https://docs.microsoft.com/en-us/samples/dotnet/try-samples/101-linq-samples/ 
    /// </summary>
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
                    program.FromWhereSelectExample();
                    break;
                case 2:
                    program.ReturnTypeIsIEnumerableExample();
                    break;
                case 3:
                    program.ChangeDatatypeOfQueryResult();
                    break;
                case 4:
                    program.ReturnAggregateValue();
                    break;
                case 5:
                    program.OrderByExample();
                    break;
                case 6:
                    program.OrderByTwoCriteria();
                    break;
                case 7:
                    program.OrderByWithDifferentStringComparer();
                    break;
                case 8:
                    program.FilterExample();
                    break;
                case 9:
                    program.GroupByExample();
                    break;
                case 10:
                    program.GroupByTwoCriteria();
                    break;
                case 11:
                    program.ToLookupExample();
                    break;
                case 12:
                    program.ConcatExample();
                    break;
                case 13:
                    program.ConcatCombinedWithOrderByExample();
                    break;
                case 14:
                    program.LetExample();
                    break;
                case 15:
                    program.IntoExample();
                    break;
                case 16:
                    program.CrossJoinExample();
                    break;
                case 17:
                    program.GroupJoin_LeftOuterJoin();
                    break;
                case 18:
                    program.GroupJoin_RightOuterJoin();
                    break;

                // Zusätzliche Beispiele
                case 19:
                    program.AllExample();
                    break;
                case 20:
                    program.LambdaAuslagern_inMethode();
                    break;
                case 21:
                    program.LambdaAuslagern_inFunc();
                    break;
                case 22:
                    program.LambdaAuslagern_inLokaleFunktion();
                    break;

                // Noch mehr Beispiele
                case 23:
                    program.FirstBeispiel();
                    break;
                case 24:
                    program.FirstOrDefaultBeispiel();
                    break;
            }
        }

        private void FromWhereSelectExample()
        {
            Console.WriteLine("--- FromWhereSelectExample ---");

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Deklaration
            // Hier wird die Abfrage noch nicht ausgeführt

            // Abfragesyntax
            //var lowNumbers =
            //    from n in numbers     // Auch hier sprechende Variablen verwenden: "n" passt in diesem Kontext, aber "number" ginge auch (siehe "x" in den Beispielen unten)
            //    where n < 5
            //    //where n < 4         // Zweite Bedingung; oder where n < 5 && n < 4
            //    select n;

            // Erweiterungsmethodensyntax
            var lowNumbers = numbers
                                            .Where(n => n < 5)
                                            .Select(x => x); // ".Select(x => x)" kann weggelassen werden, weil Where(...) bereits die gleiche Ergebnisliste zurückgibt
            //var lowNumbers = numbers.Where(n => n < 5);  // Where ist ein Filter
            //var lowNumbers = numbers.Select(n => n < 5); // Select ist eine Projektion (auf alle Elemente)
            //var lowNubmers = numbers.Sum();
            //var lowNumbers = numbers.Sum(n => n /*mitarbeiter => mitarbeiter.Lohn*/); // Sum kann auch ein Lambda verwenden, aber nicht als Filter, sondern um eine Eigenschaft auszuwählen: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum?view=netframework-4.7.2


            // Verwendung
            // Hier bei der ersten Verwendung wird die Abfrage ausgeführt
            Console.WriteLine(string.Join(", ", lowNumbers));
        }

        private void ReturnTypeIsIEnumerableExample()
        {
            int[] scores = { 32, 99, 91, 85, 50, 80 };

            // Abfragesyntax
            // Ist vom Typ IEnumerable von int
            //IEnumerable<int> scoreQuery =
            //    from score in scores
            //    where score > 80
            //    select score;

            // Erweiterungsmethodensyntax
            IEnumerable<int> scoreQuery = scores.Where(score => score > 80);

            foreach (int currentValue in scoreQuery)
            {
                Console.Write(currentValue + " ");
            }

            Console.WriteLine();
        }

        private void ChangeDatatypeOfQueryResult()
        {
            int[] scores = { 32, 99, 91, 85, 50, 80 };

            // Abfragesyntax
            // Anderer Typ als Resultat
            //IEnumerable<string> highScoreQuery =
            //    from score in scores
            //    where score > 80
            //    orderby score descending
            //    select string.Format($"The score is {score}.");

            // Erweiterungsmethodensyntax
            IEnumerable<string> highScoreQuery = scores
                .Where(score => score > 80)
                .OrderByDescending(score => score)
                .Select(score => string.Format($"The score is {score}."));

            foreach (string item in highScoreQuery)
            {
                Console.WriteLine(item);
            }
        }

        private void ReturnAggregateValue()
        {
            int[] scores = { 32, 99, 91, 85, 50, 80 };

            // Abfragesyntax
            // Ein einzelner aggregierter Wert als Resultat
            //int highScoreCount =
            //    (from score in scores
            //     where score > 80
            //     select score)
            //        .Count(); // Es existiert kein Schlüsselwort für Count() in der Abfragesyntax

            // Erweiterungsmethodensyntax
            //int highScoreCount = scores.Where(score => score > 80).Count();
            var highScoreCount = scores.Count(score => score > 80); // ReSharper "Covert LINQ to code" ausprobieren

            Console.WriteLine($"Number of high scores: {highScoreCount}");
        }

        private void OrderByExample()
        {
            string[] words = { "Mit", "LINQ", "rockt", "der", "C#", "Code" };

            // Abfragesyntax
            //IOrderedEnumerable<string> query =
            //IEnumerable<string> query = // IOrderedEnumerable<string> ist besser. IEnumerable<string> geht auch, weil ein IOrderedEnumerable<string> von IEnumerable<string> ableitet.
            //    from word in words
            //    orderby word.Length
            //    select word;

            // Erweiterungsmethodensytax
            IOrderedEnumerable<string> query = words.OrderBy(word => word.Length);       // Beachte, dass hier ein IOrderedEnumerable<T> zurückkommt und kein IEnumerable<T>
            //IOrderedEnumerable<string> query = words.OrderBy(word => word.First());          // C#-Standardsortierung mit zuerst Grossbuchstaben, dann Kleinbuchstaben
            //IOrderedEnumerable<string> query = words.OrderBy(word => word.ToLower());        // Grosse "A"s und kleine "a"s nebeneinander einsortieren
            //IOrderedEnumerable<string> query = words.OrderBy(word => word.ToLower().Last()); // Nach dem letzten Buchstaben sortieren

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        private void OrderByTwoCriteria()
        {
            var list = new[]
            {
                new {Number = 20, Color = "blue", Country = "Schweiz", Animal = "Hund"},
                new {Number = 20, Color = "green", Country = "Schweiz", Animal = "Kamel"},
                new {Number = 21, Color = "blue", Country = "Malta", Animal = "Katze"},
                new {Number = 20, Color = "blue", Country = "Schweiz", Animal = "Maus"},
                new {Number = 20, Color = "red", Country = "Malta", Animal = "Pferd"},
                new {Number = 20, Color = "red", Country = "Schweiz", Animal = "Affe"},
                new {Number = 20, Color = "red", Country = "Malta", Animal = "Huhn"}
            };

            Console.WriteLine("--- Ausgangsliste -----------");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Number}\t{item.Color}\t{item.Country}\t{item.Animal}");
            }

            Console.WriteLine("-----------------------------\n");

            Console.WriteLine("\n--- Nach zwei Eigenschaften sortieren ---");
            // Abfragesyntax
            //var query1 =
            //    from item in list
            //    orderby item.Number, item.Color
            //    select item;

            // Erweiterungsmethodensyntax
            var query1 = list.OrderBy(item => item.Number).ThenBy(item => item.Color);

            foreach (var item in query1)
            {
                Console.WriteLine($"{item.Number}\t{item.Color}\t{item.Country}\t{item.Animal}");
            }

            Console.WriteLine("\n--- Nach drei Eigenschaften sortieren ---");
            // Abfragesyntax
            //var query2 =
            //    from item in list
            //    orderby item.Number, item.Color, item.Country
            //    select item;

            // Erweiterungsmethodensyntax
            var query2 = list.OrderBy(item => item.Number).ThenBy(item => item.Color).ThenBy(item => item.Country);

            foreach (var item in query2)
            {
                Console.WriteLine($"{item.Number}\t{item.Color}\t{item.Country}\t{item.Animal}");
            }
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparer?view=net-6.0#properties
        /// https://stackoverflow.com/questions/15968625/culture-info-names/15968700#15968700
        ///     - List of CultureInfo names
        /// https://stackoverflow.com/questions/4208244/get-current-language-in-cultureinfo
        ///     - CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        /// https://docs.microsoft.com/en-us/dotnet/standard/base-types/best-practices-strings#choosing-a-stringcomparison-member-for-your-method-call
        ///     - Choosing a StringComparison member for your method call:
        /// https://stackoverflow.com/questions/492799/difference-between-invariantculture-and-ordinal-string-comparison
        ///     - var s1 = "Strasse";
        ///       var s2 = "Straße";
        ///       s1.Equals(s2, StringComparison.Ordinal);           //false
        ///       s1.Equals(s2, StringComparison.InvariantCulture);  //true
        /// https://stackoverflow.com/questions/1832684/c-sharp-sort-and-orderby-comparison/1832706#1832706
        ///     - Sort order is stable, meaning: if the keys of two elements are equal, the order of the elements is preserved.
        /// https://aakinshin.net/posts/how-sorting-order-depends-on-runtime-and-operating-system/#conclusion
        ///     - Here are a few practical recommendations that can help you avoid tricky and painful bugs in the future:
        ///         - If you want to achieve consistent string comparison across different runtimes and operating systems, always use StringComparer.Ordinal.
        ///         - If you don't use StringComparer.Ordinal, always keep in mind that the sorting order may depend on runtime, operating system, current culture, and environment variables.
        /// https://en.wikipedia.org/wiki/Alphabetical_order#Language-specific_conventions
        /// https://stackoverflow.com/questions/48700350/linq-orderby-is-not-sorting-correctly
        ///     - 
        /// </summary>
        private void OrderByWithDifferentStringComparer()
        {
            string[] text1 = { "Mit", "LINQ", "rockt", "der", "C#", "code", "Code" };
            string[] text2 = { "und", "er", "wird", "schlanker" };


            IEnumerable<string> concatQuery1 = text1.Concat(text2).OrderBy(word => word); // Der Standard-Comparer ist culture-specific
            IEnumerable<string> concatQuery2 = text1.Concat(text2).OrderBy(word => word, StringComparer.Ordinal); // https://stackoverflow.com/questions/2967208/change-c-sharp-sorting-behaviour/2981133#2981133
            IEnumerable<string> concatQuery3 = text1.Concat(text2).OrderBy(word => word, StringComparer.OrdinalIgnoreCase);
            IEnumerable<string> concatQuery4 = text1.Concat(text2).OrderBy(word => word, StringComparer.InvariantCulture);

            Console.WriteLine("--- Default ---");
            foreach (string word in concatQuery1)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("\n--- StringComparer.Ordinal (beachte wo 'code' landet)---");
            foreach (string word in concatQuery2)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("\n--- StringComparer.OrdinalIgnoreCase (beachte wo 'code' landet) ---");
            foreach (string word in concatQuery3)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("\n--- StringComparer.InvariantCulture ---");
            foreach (string word in concatQuery4)
            {
                Console.WriteLine(word);
            }
        }

        private void FilterExample()
        {
            string[] words = { "Mit", "LINQ", "rockt", "der", "C#", "Code" };

            // Abfragesyntax
            //IEnumerable<string> query =
            //    from word in words
            //    where word.Length == 4
            //    select word;

            // Erweiterungsmethodensyntax
            IEnumerable<string> query = words.Where(word => word.Length == 4);
            //IEnumerable<string> query = words.Where(word => word.StartsWith("C"));

            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }

        private void GroupByExample()
        {
            List<int> numbers = new List<int> { 56, 25, 65, 10, 64, 52313, 3, 216 };

            // Abfragesyntax
            //IEnumerable<IGrouping<int, int>> query =
            //    from number in numbers
            //    group number by number % 2;

            // Erweiterungsmethodensyntax
            IEnumerable<IGrouping<int, int>> groups = numbers.GroupBy(number => number % 2); // IGrouping<TKey, TElement>
                                                                                             // TKey ist der Type nach dem gruppiert wird, hier int (könnte z.B. auch "Augenfarbe" sein)
                                                                                             // TElement ist der Type der gruppierten Objekte, hier auch int (könnte aber z.B. "Person" sein)

            foreach (IGrouping<int, int> group in groups)
            {
                Console.WriteLine(group.Key == 0
                    ? "\nGerade Zahlen (erste Gruppe):"
                    : "\nUngerade Zahlen (zweite Gruppe):");
                foreach (int number in group)
                {
                    Console.WriteLine(number);
                }
            }
        }

        private void GroupByTwoCriteria()
        {
            var list = new[]
            {
                new {Number = 20, Color = "blue", Country = "Schweiz", Animal = "Hund"},
                new {Number = 20, Color = "green", Country = "Schweiz", Animal = "Kamel"},
                new {Number = 21, Color = "blue", Country = "Malta", Animal = "Katze"},
                new {Number = 20, Color = "blue", Country = "Schweiz", Animal = "Maus"},
                new {Number = 20, Color = "red", Country = "Malta", Animal = "Pferd"},
                new {Number = 20, Color = "red", Country = "Schweiz", Animal = "Affe"},
                new {Number = 20, Color = "red", Country = "Malta", Animal = "Huhn"}
            };

            Console.WriteLine("--- Ausgangsliste -----------");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Number}\t{item.Color}\t{item.Country}\t{item.Animal}");
            }

            Console.WriteLine("-----------------------------\n");

            // Abfragesyntax
            //var query =
            //    from element in list
            //    group element by new {element.Number, element.Color};

            // Erweiterungsmethodensyntax
            var groups = list.GroupBy(item => new { item.Number, item.Color });

            Console.WriteLine("\n--- Nach zwei Eigenschaften gruppiert ---");
            Console.WriteLine("-----------------------------\n");
            foreach (var group in groups)
            {
                Console.WriteLine($"\nGruppiert nach {group.Key}");
                foreach (var item in group) // Beachte: hier kann man "var" nicht mit einem konkreten Typ ersetzen, weil es ein anonymer Typ ist
                {
                    Console.WriteLine($"\t{item.Number}\t{item.Color}\t{item.Country}\t{item.Animal}");
                }
            }

            Console.WriteLine("-----------------------------\n");
        }

        private void ToLookupExample()
        {
            // ToLookup is the same as GroupBy; the only difference is GroupBy execution is deferred,
            // whereas ToLookup execution is immediate. Also, ToLookup is only applicable in Method
            // syntax. ToLookup is not supported in the query syntax.
            // Source: http://www.tutorialsteacher.com/linq/linq-grouping-operator-groupby-tolookup

            // Erklärung: http://geekswithblogs.net/BlackRabbitCoder/archive/2011/03/24/c.net-little-wonders-the-tolookup-linq-extension-method.aspx

            var list = new[]
            {
                new {Number = 20, Color = "blue", Country = "Schweiz", Animal = "Hund"},
                new {Number = 20, Color = "green", Country = "Schweiz", Animal = "Kamel"},
                new {Number = 20, Color = "blue", Country = "Malta", Animal = "Katze"},
                new {Number = 20, Color = "blue", Country = "Schweiz", Animal = "Maus"},
                new {Number = 20, Color = "red", Country = "Malta", Animal = "Pferd"},
                new {Number = 20, Color = "red", Country = "Schweiz", Animal = "Affe"},
                new {Number = 20, Color = "red", Country = "Malta", Animal = "Huhn"}
            };

            Console.WriteLine("--- Ausgangsliste -----------");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Number}\t{item.Color}\t{item.Country}\t{item.Animal}");
            }

            Console.WriteLine("-----------------------------\n");

            // Abfragesyntax
            // ToLookup(...) gibt es nicht in der Abfragesyntax, sondern nur in der Erweiterungsmethodensyntax

            // Erweiterungsmethodensyntax
            // Die Abfrage ist hier bereits ausgeführt
            // und nicht erst beim foreach wie bei den
            // meisten anderen LINQ-Methoden
            var query = list.ToLookup(item => item.Color);

            foreach (var group in query)
            {
                Console.WriteLine($"\n--- Key: {group.Key} ---");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.Number}\t{item.Color}\t{item.Country}\t{item.Animal}");
                }
            }

            Console.WriteLine("\n--- Rote Elemente mit query[\"red\"] abfragen ---");
            var listOfRedElements = query["red"]; // Auf die roten Elemente zugreifen
            foreach (var redElement in listOfRedElements)
            {
                Console.WriteLine(
                    $"{redElement.Number}\t{redElement.Color}\t{redElement.Country}\t{redElement.Animal}");
            }
        }

        private void ConcatExample()
        {
            string[] text1 = { "Mit", "LINQ", "rockt", "der", "C#", "Code" };
            string[] text2 = { "und", "er", "wird", "schlanker" };

            // Abfragesyntax
            //IEnumerable<string> concatQuery =
            //    from word in
            //        (from text in text1
            //            select text)
            //        .Concat(
            //            from text in text2
            //            select text)
            //    select word; // Es existiert kein Schlüsselwort für Concat(...) in der Abfragesyntax

            // Erweiterungsmethodensyntax
            IEnumerable<string> concatQuery = text1.Concat(text2);

            foreach (string word in concatQuery)
            {
                Console.WriteLine(word);
            }
        }

        private void ConcatCombinedWithOrderByExample()
        {
            string[] text1 = { "Mit", "LINQ", "rockt", "der", "C#", "Code" };
            string[] text2 = { "und", "er", "wird", "schlanker" };

            // Abfragesyntax
            //IEnumerable<string> concatQuery =
            //    from word in
            //        (from text in text1
            //            select text)
            //        .Concat(
            //            from text in text2
            //            select text)
            //    orderby word
            //    select word; // Es existiert kein Schlüsselwort für Concat(...) in der Abfragesyntax

            // Erweiterungsmethodensyntax
            IEnumerable<string> concatQuery = text1.Concat(text2).OrderBy(word => word);

            foreach (string word in concatQuery)
            {
                Console.WriteLine(word);
            }
        }

        /// <summary>
        /// LINQ: LET vs INTO https://youtu.be/u5ZW8-lPEeY 
        /// 
        /// "let" erzeugt eine neue Variable, die in der Abfrage verwendet werden kann
        /// 
        /// Let – Doesn’t hide the previous variable and creates a new variable. Which means you create a new variable and you can also use the previous variable, so you can use both in further operations.
        /// Source: http://www.codeproject.com/Articles/231164/Into-and-let-in-LINQ-Let-vs-Into
        /// 
        /// "let" existiert nicht in der Erweiterungsmethodensyntax bzw. wird mit Select(...) umgesetzt.
        /// Siehe dazu http://stackoverflow.com/a/1092770
        /// </summary>
        private void LetExample()
        {
            var numbers = Enumerable.Range(1, 100);

            // Variante 1 ohne let
            var even1 =
                from n in numbers       // Warnung "Possible multiple enumeration" absichtlich dringelassen, damit man sich dem bewusst wird
                                        // Erklärung: https://www.jetbrains.com/help/resharper/PossibleMultipleEnumeration.html#false-positives
                                        // Erklärung: https://stackoverflow.com/a/8240935
                where n % 2 == 0
                select new
                {
                    Number = n,
                    IsEven = n % 2 == 0
                };

            // Variante 2 mit let: sprechender und keine Codeduplikation
            var even2 =
                from n in numbers
                let isEven = n % 2 == 0
                where isEven
                select new
                {
                    Number = n,
                    IsEven = isEven
                };

            // Erweiterungsmethodensyntax, wo "let" mit einem Select-Zwischenkonstrukt umgesetzt wird
            var even3 = numbers
                .Select(n => new { IsEven = n % 2 == 0, number = n }) // Zwischenkontrukt für let
                .Where(n => n.IsEven)
                .Select(n => new { Number = n.number, n.IsEven });

            foreach (var evenNumber in even3)
            {
                Console.WriteLine($"{evenNumber.Number} is {evenNumber.IsEven}");
            }
        }


        /// <summary>
        /// LINQ: LET vs INTO https://youtu.be/u5ZW8-lPEeY 
        /// 
        /// "into" speichert das Ergebnis der Abfrage in eine Variable, womit eine
        /// neue Abfrage begonnen werden kann
        /// 
        /// Into – Hides the previous variable when used in a query, as you see in the above example. Which means its hides the previous range variable and creates a temporary range variable which you can use in further operations.
        /// Source: http://www.codeproject.com/Articles/231164/Into-and-let-in-LINQ-Let-vs-Into
        /// 
        /// "into" existiert nicht in der Erweiterungsmethodensyntax bzw. wird mit Select(...) umgesetzt.
        /// Siehe dazu http://stackoverflow.com/a/24308845
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private void IntoExample()
        {
            var numbers = Enumerable.Range(1, 100);

            // Variante 1
            var oddMultiplesOf5_v1 =
                from n in numbers
                where n % 5 == 0 && n % 2 != 0
                select n;

            // Variante 2 mit into
            var oddMultiplesOf5_v2 =
                from n in numbers
                where n % 5 == 0
                select n
                into multiplesOf5 // Hier fängt ein neuer Kontext an, d.h. Variablen vom oberen
                                  // Kontext wie n sind hier nicht mehr verfügbar
                                  //&& n == 10 // geht nicht
                where multiplesOf5 % 2 != 0
                select multiplesOf5;

            foreach (int i in oddMultiplesOf5_v2)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Cross-Join ist das karthesische Produkt zweier Listen.
        /// 
        /// Beachte, dass die Variante in der Erweiterungsmethodensyntax ganz anders aussieht
        /// als die Variante in der Abfragesyntax.
        /// 
        /// Quelle: http://linqsamples.com/linq-to-objects/projection/SelectMany-lambda-csharp
        /// 
        /// SelectMany(...):
        /// - http://www.dotnetperls.com/selectmany
        /// - https://dzone.com/articles/selectmany-probably-the-most-p
        /// - https://youtu.be/zQnkh8GpUQU
        /// - http://stackoverflow.com/questions/9115675/nested-from-linq-query-expressed-with-extension-methods
        /// </summary>
        private void CrossJoinExample()
        {
            CrossJoinExample_Abfragesyntax();
            CrossJoinExample_Erweiterungsmethodensyntax();
        }

        private void CrossJoinExample_Abfragesyntax()
        {
            Console.WriteLine("\nCrossJoinExample_Abfragesyntax()");

            string[] fruits = { "Grape", "Orange", "Apple" };
            int[] amounts = { 1, 2 /*, 3*/};

            // Abfragesyntax
            var crossJoin =
                from fruit in fruits
                from amount in amounts
                select new { Fruit = fruit, Amount = amount };

            foreach (var item in crossJoin)
            {
                Console.WriteLine($"{item.Fruit}, {item.Amount}");
            }
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private void CrossJoinExample_Erweiterungsmethodensyntax()
        {
            Console.WriteLine("\nCrossJoinExample_Erweiterungsmethodensyntax()");

            string[] fruits = { "Grape", "Orange", "Apple" };
            int[] amounts = { 1, 2 /*, 3*/};

            var crossJoin = // https://youtu.be/zQnkh8GpUQU?t=8m58s
                fruits.SelectMany(
                    fruit => amounts /*1. Lambda*/, // Gleichbedeutend mit fruit => { return amounts; }
                                                    // Gesprochen
                                                    // "Für jedes fruit-Element aus der Liste fruits
                                                    // retourniere amounts" und dann...
                    (fruit, amount) => new { Fruit = fruit, Amount = amount } /*2. Lambda*/
                // ... führe die Kombination von fruit mit jedem amount
                // aus der Liste amounts über in den anonymen Typen
                );

            foreach (var item in crossJoin)
            {
                Console.WriteLine($"{item.Fruit}, {item.Amount}");
            }
        }

        /// <summary>
        /// Group-Join ist equivalent mit dem SQL Outer-Join (left outer join und right outer join).
        /// 
        /// Quelle:
        /// - http://stackoverflow.com/a/15599143
        /// - http://www.dotnetperls.com/groupjoin
        /// </summary>
        private void GroupJoin_LeftOuterJoin()
        {
            GroupJoin_LeftOuterJoin_Abfragesyntax();
            GroupJoin_LeftOuterJoin_Erweiterungsmethodensyntax();
        }

        [SuppressMessage("ReSharper", "RedundantAnonymousTypePropertyName")]
        private void GroupJoin_LeftOuterJoin_Abfragesyntax()
        {
            Console.WriteLine("\nGroupJoin_LeftOuterJoin_Abfragesyntax");

            var parents = new[]
            {
                new {Id = 1, ParentValue = "A"},
                new {Id = 2, ParentValue = "B"},
                new {Id = 3, ParentValue = "C"}
            };

            var children = new[]
            {
                new {Id = 1, ChildValue = "a1"},
                new {Id = 1, ChildValue = "a2"},
                new {Id = 1, ChildValue = "a3"},
                new {Id = 2, ChildValue = "b1"},
                new {Id = 2, ChildValue = "b2"}
            };

            // http://stackoverflow.com/a/14576195
            var leftOuterJoin =
                from parent in parents
                join child in children on parent.Id equals child.Id into joined
                from item in joined.DefaultIfEmpty()
                select new { ParentValue = parent.ParentValue, ChildValue = (item == null ? string.Empty : item.ChildValue) };

            // Erklärung allgemein für DefaultIfEmpty():
            // Wenn es auf der rechten Seite kein Ergebnis für den Join gibt,
            // soll trotzdem ein Standartwert retourniert werden, damit eine
            // Zeile angezeigt werden kann.
            //
            // Erklärung konkret für DefaultIfEmpty():
            // Für parent(id=3) gibt es keinen Treffer in der children-Tabelle.
            // Damit wir trotzdem eine Zeile mit "C, <leer>" anzeigen können,
            // soll für den nicht vorhanden "C, X"-Fall für X ein Default zurückgegeben
            // werden, in diesem Fall ist der Default für den anonymen Typ (Referenztyp)
            // null. Und mit dem null können wir dann weiterarbeiten.
            //
            // Quelle: https://docs.microsoft.com/en-us/dotnet/csharp/linq/perform-left-outer-joins


            foreach (var item in leftOuterJoin)
            {
                Console.WriteLine($"{item.ParentValue}, {item.ChildValue}");
            }
        }

        /// <summary>
        /// https://code.msdn.microsoft.com/LINQ-Join-Operators-dabef4e9
        /// https://docs.microsoft.com/en-us/dotnet/csharp/linq/perform-left-outer-joins#
        /// </summary>
        [SuppressMessage("ReSharper", "RedundantAnonymousTypePropertyName")]
        private void GroupJoin_LeftOuterJoin_Erweiterungsmethodensyntax()
        {
            Console.WriteLine("\nGroupJoin_LeftOuterJoin_Erweiterungsmethodensyntax");

            var parents = new[]
            {
                new {Id = 1, ParentValue = "A"},
                new {Id = 2, ParentValue = "B"},
                new {Id = 3, ParentValue = "C"}
            };

            var children = new[]
            {
                new {Id = 1, ChildValue = "a1"},
                new {Id = 1, ChildValue = "a2"},
                new {Id = 1, ChildValue = "a3"},
                new {Id = 2, ChildValue = "b1"},
                new {Id = 2, ChildValue = "b2"},
            };

            var leftOuterJoin =
                parents.GroupJoin(children,
                    parent => parent.Id,
                    child => child.Id,
                    (parent, result) => new { ParentValue = parent.ParentValue, Result = result });

            foreach (var item in leftOuterJoin)
            {
                Console.WriteLine($"\n--- {item.ParentValue}: ---");
                foreach (var resultItem in item.Result)
                {
                    Console.WriteLine($"{item.ParentValue}, {resultItem.ChildValue} ");
                }
            }
        }

        private void GroupJoin_RightOuterJoin()
        {
            GroupJoin_RightOuterJoin_Abfragesyntax();
            GroupJoin_RightOuterJoin_Erweiterungsmethodensyntax();
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        private void GroupJoin_RightOuterJoin_Abfragesyntax()
        {
            Console.WriteLine("\n\nGroupJoin_RightOuterJoin_Abfragesyntax");

            var parents = new[]
            {
                new {Id = 1, ParentValue = "A"},
                new {Id = 2, ParentValue = "B"},
                new {Id = 3, ParentValue = "C"}
            };

            var children = new[]
            {
                new {Id = 1, ChildValue = "a1"},
                new {Id = 1, ChildValue = "a2"},
                new {Id = 1, ChildValue = "a3"},
                new {Id = 2, ChildValue = "b1"},
                new {Id = 2, ChildValue = "b2"},
                new {Id = 4, ChildValue = "d1"}
            };

            // http://www.dotnetfunda.com/codes/show/1849/how-to-use-left-right-outer-join-in-linq
            var rightOuterJoin =
                from child in children
                join parent in parents on child.Id equals parent.Id into joined
                from parent in joined.DefaultIfEmpty()
                select new
                {
                    ParentValue = parent == null ? "-" : parent.ParentValue,
                    ChildValue = (child == null ? "-" : child.ChildValue)
                };

            foreach (var item in rightOuterJoin)
            {
                Console.WriteLine($"{item.ParentValue}, {item.ChildValue}");
            }
        }

        private void GroupJoin_RightOuterJoin_Erweiterungsmethodensyntax()
        {
            Console.WriteLine("\nGroupJoin_RightOuterJoin_Erweiterungsmethodensyntax");

            var parents = new[]
            {
                new {Id = 1, ParentValue = "A"},
                new {Id = 2, ParentValue = "B"},
                new {Id = 3, ParentValue = "C"}
            };

            var children = new[]
            {
                new {Id = 1, ChildValue = "a1"},
                new {Id = 1, ChildValue = "a2"},
                new {Id = 1, ChildValue = "a3"},
                new {Id = 2, ChildValue = "b1"},
                new {Id = 2, ChildValue = "b2"},
                new {Id = 4, ChildValue = "d1"}
            };

            var rightOuterJoin =
                children.GroupJoin(parents,
                    child => child.Id,
                    parent => parent.Id,
                    (child, result) => new { child.ChildValue, Result = result });

            foreach (var item in rightOuterJoin)
            {
                Console.WriteLine($"\n--- {item.ChildValue} --- ");
                foreach (var resultItem in item.Result)
                {
                    Console.WriteLine($"{resultItem.ParentValue}, {item.ChildValue} ");
                }
            }
        }

        private void AllExample()
        {
            Console.WriteLine("--- AllExample ---");

            string[] paths =
            {
                @"c:\temp\berg1.jpg",
                @"c:\temp\berg2.jpg",
                @"c:\temp\berg2.gif"
            };

            // Mit foreach sind es 9 Zeilen Code, mit LINQ 1 Zeile Code
            //bool allFilesAreJpgs = true;
            //foreach (string path in paths)
            //{
            //    if (!path.EndsWith("jpg"))
            //    {
            //        allFilesAreJpgs = false;
            //        break;
            //    }
            //}

            bool alleDateienSindJpgs = paths.All(path => path.EndsWith("jpg"));
            Console.WriteLine($"Alle Dateien sind jpg-Dateien: {alleDateienSindJpgs}");
        }

        private void LambdaAuslagern_inMethode()
        {
            Console.WriteLine("--- LambdaAuslagern_inMethode ---");

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Abfragesyntax
            //var lowNumbers =
            //    from n in numbers
            //    where IstZahlKleinerAlsFünf(n) // Der Ausdruck wird in eine Methode int->bool ausgelagert und sprechend benannt
            //    select n;

            // Erweiterungsmethodensyntax
            var lowNumbers = numbers.Where(IstZahlKleinerAlsFünf); // Der Ausdruck wird in eine Methode int->bool ausgelagert und sprechend benannt
            Console.WriteLine(string.Join(", ", lowNumbers));
        }

        private bool IstZahlKleinerAlsFünf(int n)
        {
            return n < 5;
        }

        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        private void LambdaAuslagern_inFunc()
        {
            Console.WriteLine("--- LambdaAuslagern_inFunc ---");

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Der Lambda-Ausdruck wird in ein Func<int, bool> ausgelagert und sprechend benannt
            Func<int, bool> zahlIstKleinerAlsFünf = n => n < 5;

            // Abfragesyntax
            //var lowNumbers =
            //    from n in numbers
            //    where zahlIstKleinerAlsFünf(n) // Der Lambda-Ausdruck wird in ein Func<int, bool> ausgelagert und sprechend benannt
            //    select n;

            // Erweiterungsmethodensyntax
            var lowNumbers = numbers.Where(zahlIstKleinerAlsFünf); // Der Lambda-Ausdruck wird in ein Func<int, bool> ausgelagert und sprechend benannt
            Console.WriteLine(string.Join(", ", lowNumbers));
        }

        private void LambdaAuslagern_inLokaleFunktion()
        {
            Console.WriteLine("--- LambdaAuslagern_inLokaleFunktion ---");

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Der Lambda-Ausdruck wird in eine lokale Funktion ausgelagert und sprechend benannt; das ist eine "C# 7 (2017)"-Funktionalität
            bool ZahlIstKleinerAlsFünf(int n) => n < 5;

            // Abfragesyntax
            //var lowNumbers =
            //    from n in numbers
            //    where ZahlIstKleinerAlsFünf(n) // Der Lambda-Ausdruck wird in eine lokale Funktion ausgelagert und sprechend benannt; das ist eine "C# 7 (2017)"-Funktionalität
            //    select n;

            // Erweiterungsmethodensyntax
            var lowNumbers = numbers.Where(ZahlIstKleinerAlsFünf); // Der Lambda-Ausdruck wird in eine lokale Funktion ausgelagert und sprechend benannt; das ist eine "C# 7 (2017)"-Funktionalität
            Console.WriteLine(string.Join(", ", lowNumbers));
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.first?view=net-6.0
        /// https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.last?view=net-6.0
        /// https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.single?view=net-6.0
        /// 
        /// </summary>
        private void FirstBeispiel()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 3, 7, 2, 0 };

            var ergebnis = numbers.First(number => number == 3); // Fängt von vorne die List an zu durchsuchen und retourniert den
            // ersten Fund (auch wenn es mehrere Treffer gibt)
            //var ergebnis = numbers.First(number => number == 10);     // Wirft eine Exception, wenn kein Element gefunden wird
            // System.InvalidOperationException: Sequence contains no matching element

            Console.WriteLine($"{nameof(ergebnis)} = {ergebnis}");
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault?view=net-6.0 (06.02.2022)
        /// https://stackoverflow.com/questions/1024559/when-to-use-first-and-when-to-use-firstordefault-with-linq (06.02.2022)
        /// </summary>
        private void FirstOrDefaultBeispiel()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 3, 7, 2, 0 };

            var ergebnis = numbers.FirstOrDefault(number => number == 70); // Fängt von vorne die List an zu durchsuchen und retourniert
            // den ersten Fund (auch wenn es mehrere Treffer gibt)
            // Im Gegensatz zu First() wird keine Exception geworfen, wenn
            // nichts gefunden wird; stattdessen wird der Default-Wert retourniert
            Console.WriteLine($"{nameof(ergebnis)} = {ergebnis}");
        }
    }
}