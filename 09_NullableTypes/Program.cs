using System.Diagnostics.CodeAnalysis;
#pragma warning disable 219
#pragma warning disable 168

namespace _09_NullableTypes
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
                    ErklärungDerBedeutungVonNull();
                    break;
                case 2:
                    Beispiele();
                    break;
                case 3:
                    HasValueAbfrage();
                    break;
                case 4:
                    BeispielMitFranken();
                    break;
                case 5:
                    NullCoalescingOperator();           // ??
                    break;
                case 6:
                    NullCoalescingOperatorBeispiel2();  // ??
                    break;
                case 7:
                    SafeNavigationOperator();           // ?.
                    break;
                case 8:
                    SafeNavigationOperatorBeispiel2();  // ?.
                    break;
                case 9:
                    Bedingungsoperator();               // ?:
                    break;
            }
        }

        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private static void ErklärungDerBedeutungVonNull()
        {
            // Definition
            //    Q: Was drückt "null" aus?
            //    A: Variablen ist nicht initialisiert; hat keine Referenz auf einen Wert.
            string s1;              // Gleichbedeutend mit der nächsten Zeile
            string s2 = null!;       // "null" bedeutet "undefiniert", sprich, wir haben die Variable s nicht definiert, nicht initialisiert
                                    // Ausprache
                                    //    null: [nall]
                                    //    0   : [null] = (dt.) Null = Zahl 0 = (engl.) zero
                                    //Console.WriteLine($"s1 = {s1}"); // Auf nicht-initialisierte Variablen kann man nicht zugreifen
            Console.WriteLine($"s2 = [{s2}]");   // Wenn man der Variable explizit null zuweist, kann man auf die Variable zugreifen

            // Wertetypen sind normalerweise _nie_ null; der Kompiler erzwingt, dass die Variable vor der ersten Verwendung initialisiert wird
            int i;
            //Console.WriteLine(i); // Siehe Error: Use of unassigned local variable 'i'
            //i = null;             // Geht nicht, Error sagt: CS0037 Cannot convert null to 'int' because it is a non - nullable value type

            // Wertetypen können nur null sein, wenn wir sie explizit mit dem Fragezeichen als "nullable" deklarieren
            int? j;
            j = null;               // Im Gegensatz zum Beispiel oben, ist die Zuweisung von null jetzt möglich
            Console.WriteLine($"j = [{j}]");


            // Referenztypen sind normalerweise _immer_ null, bis wir sie initialisieren
            string s3 = null!;                                       // s3 ist null
            Console.WriteLine($"{nameof(s3)} = [{s3}]");               // Das geht, weil Console.WriteLine(...) mit null umgehen kann und im null-Fall einfach nichts auf die Konsole ausgibt
            Console.WriteLine($"{nameof(s3.Length)} = [{s3.Length}]"); // Das geht aber nicht; bei Versuch auf ein null-Objekt zuzugreifen, stürtz das Programm ab
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void Beispiele()
        {
            int? number = null;
            int? counter = 10;
            double? amount = null;
            bool? editMode = true;
            bool? isGoodChessPlayer = null;
            char? letter = 'z';
            int?[] lottoNumbers = new int?[6];
        }

        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        private static void HasValueAbfrage()
        {
            // Ohne if-Abfrage
            //int? nullNumber = null;
            //Console.WriteLine(nullNumber.Value); // Führt zu Unhandled Exception: System.InvalidOperationException: Nullable object must have a value.

            // Mit if-Abfrage
            int? number = 10;
            //int? number = null;
            if (number.HasValue)                                    // Es geht auch: if (number != null)
            {
                Console.WriteLine($"number.Value: {number.Value}"); // Es geht auch: Console.WriteLine($"number.Value: {number}");
            }
            else
            {
                Console.WriteLine("\"number\" is nicht definiert.");
            }
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        [SuppressMessage("ReSharper", "RedundantBoolCompare")]
        private static void BeispielMitFranken()
        {
            double? amountInSwissFrancs = null;
            double exchangeRateChfToEuro = 1.108;
            double amountInEuro = 0;

            if (amountInSwissFrancs.HasValue == true) // Testen, ob der Wert zugewiesen ist
            {
                amountInEuro = amountInSwissFrancs.Value * exchangeRateChfToEuro;
            }
            else
            {
                amountInEuro = 0;
            }

            Console.WriteLine($"Betrag in Euro: {amountInEuro}");
        }

        [SuppressMessage("ReSharper", "ConstantNullCoalescingCondition")]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        private static void NullCoalescingOperator()
        {
            int? dbItemId = 2;
            //int? dbItemId = null;
            int id = dbItemId ?? -1;
            Console.WriteLine($"{nameof(dbItemId)} = {dbItemId}");
            Console.WriteLine($"{nameof(id)} = {id}");

            // ?? ist äquivalent zu diesem if-Konstrukt
            if (dbItemId != null)
            {
                id = dbItemId.Value;  // Value ist vom Typ int (nicht int?)
                //id = (int)dbItemId; // Alterative zur obigen Zeile
            }
            else
            {
                id = -1;
            }
            Console.WriteLine($"{nameof(dbItemId)} = {dbItemId}");
            Console.WriteLine($"{nameof(id)} = {id}");
        }

        [SuppressMessage("ReSharper", "ConstantNullCoalescingCondition")]
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static void NullCoalescingOperatorBeispiel2()
        {
            double? amountInSwissFrancs1 = null;
            double? amountInSwissFrancs2 = 100;
            double exchangeRateChfToEuro = 1.108;
            double amountInEuro = 0;

            amountInEuro = (amountInSwissFrancs1 ?? 0) * exchangeRateChfToEuro;
            Console.WriteLine($"Betrag in Euro: {amountInEuro}");
            amountInEuro = (amountInSwissFrancs2 ?? 0) * exchangeRateChfToEuro;
            Console.WriteLine($"Betrag in Euro: {amountInEuro}");
        }

        [SuppressMessage("ReSharper", "NotAccessedVariable")]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        [SuppressMessage("ReSharper", "ConstantConditionalAccessQualifier")]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private static void SafeNavigationOperator()
        {
            int[] zahlen = null!;            // Mit null
            int? length = zahlen.Length;   // "?" entfernen und Fehlermeldung "Possible 'System.NullReferenceException'" anschauen
            int? zahl1 = zahlen?[0];
            int? zahl2 = zahlen?[1];
            Console.WriteLine($"{nameof(zahl1)} = {zahl1}");
            Console.WriteLine($"{nameof(zahl2)} = {zahl2}");

            // "int? length = zahlen?.Length" ist äquivalent zu
            if (zahlen == null)
            {
                length = null;
            }
            else
            {
                length = zahlen.Length; // Ohne "?" ist hier sicher, weil wir den null-Fall durch die if-Abfrage verhindern
            }

            zahlen = new int[2]; // Jetzt mit Initialisierung
            length = zahlen?.Length;
            zahl1 = zahlen?[0];
            zahl2 = zahlen?[1];
            Console.WriteLine($"{nameof(zahl1)} = {zahl1}");
            Console.WriteLine($"{nameof(zahl2)} = {zahl2}");

            string eingabe = null!;
            string text = eingabe.ToUpper(); // Siehe Fehlermeldung beim Mouse-over: Possible 'System.NullReferenceException', weil wir kein "eingabe?.ToUpper()" verwenden


            // Nutzen der "?."-Notation: kürzerer Code
            //
            // Kurzschreibweise:
            // Augenfarbe augenfarbe = person?.Aussehen?.Augenfarbe;
            //
            // Alte Schreibweise, bevor es den "?."-Operator gab
            // if (person != null)
            // {
            //     if (person.Aussehen != null)
            //     {
            //         if (person.Aussehen.Augenfarbe != null)
            //         {
            //               augenfarbe = person.Aussehen.Augenfarbe;
            //         }
            //         else
            //         {
            //               augenfarbe = null;
            //         }
            //     }
            // }
        }

        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        [SuppressMessage("ReSharper", "ConstantConditionalAccessQualifier")]
        private static void SafeNavigationOperatorBeispiel2()
        {
            string eingabe = null!;
            string text = eingabe.ToUpper();
            Console.WriteLine($"{nameof(text)} = {text}");

            eingabe = "Hallo";
            text = eingabe?.ToUpper()!;
            Console.WriteLine($"{nameof(text)} = {text}");
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static void Bedingungsoperator() // Englisch: ternary operator. Umgangssprachlich: Elvis-Operator
        {
            int a = 90;
            int b = 20;

            int discountPercent = a + b > 100 ? 10 : 2;

            Console.WriteLine($"{nameof(discountPercent)} = {discountPercent}");

            // int discountPercent = a + b > 100 ? 10 : 2; is äquivalent zu
            if (a + b > 100)    // Mit der Maus über "if" fahren und ReShaper-Vorschlag "Convert to "?:" expression" ausprobieren
            {
                discountPercent = 10;
            }
            else
            {
                discountPercent = 2;
            }
        }
    }
}
