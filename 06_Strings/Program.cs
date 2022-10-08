using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06_Strings
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
                    StringBeispiele();
                    break;
                case 2:
                    StringsSindUnveränderlich();
                    break;
                case 3:
                    StringVergleiche();
                    break;
                case 4:
                    EinigeStringMethoden();
                    break;
                case 5:
                    StringBuilderBeispiel();
                    break;
                case 6:
                    StringBuilderStringsVerändern();
                    break;
            }
        }

        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        [SuppressMessage("ReSharper", "RedundantNameQualifier")]
        [SuppressMessage("ReSharper", "StringLiteralAsInterpolationArgument")]
        private static void StringBeispiele()
        {
            System.String greeting = "Hello, World!";           // Deklaration
            string greeting2 = "alias";                         // Alias

            string message = "They said, \"Hello!\"";           // Escape von Anführungszeichen, weil Anführungszeichen eine spezielle Bedeutung als String-Begrenzer haben bei Strings
            string path1 = "c:\\User\\someone";                 // Escape von Backslash, weil Backslash eine spezielle Bedeutung als Escape-Zeichen haben bei Strings
            string path2 = @"c:\User\someone";                  // Verbatim String; kann auch über mehrere Zeilen gehen (siehe Beispiel unten)
            string message2 = @"They said, ""Hello!"" ";        // Spezialfall: wenn es im String Gänsefüsschen (double quote) hat, muss ein zusätzliches Gänsefüsschen davor gesetzt werden
                                                                // https://stackoverflow.com/a/556142
            string message3 = $@"They said, {path1} {{Hello}}"; // Spezialfall wenn "$" mit "@" kombiniert wird: "path" wird ersetzt, "Hello" nicht
                                                                // - Einerseits muss "$@" stehen und nicht umgekehrt "@$"
                                                                //         - Änderung: ab C# 8.0 gehen beide Reihenfolgen "$@" und "@$":https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8?WT.mc_id=dotnet-00000-mairacw#enhancement-of-interpolated-verbatim-strings
                                                                // - Andererseits muss man für geschweifte Klammern verdoppeln, wenn man keine String-Interpolation will
                                                                //
                                                                // Dokumentation:
                                                                // Only a quote escape sequence ("") is not interpreted literally; it produces a single quotation mark.
                                                                // Additionally, in case of a verbatim interpolated string brace escape sequences ({{ and }}) are not interpreted
                                                                // literally; they produce single brace characters.
                                                                // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/verbatim
            Console.WriteLine($"{nameof(greeting)}: {greeting}");
            Console.WriteLine($"{nameof(greeting2)}: {greeting2}");
            Console.WriteLine($"{nameof(message)}: {message}");
            Console.WriteLine($"{nameof(path1)}: {path1}");
            Console.WriteLine($"{nameof(path2)}: {path2}");
            Console.WriteLine($"{nameof(message2)}: {message2}");
            Console.WriteLine($"{nameof(message3)}: {message3}");

            string multilineVerbatimString = @"This is a
                                               multiline verbatim string"; // Vorangehenden Leerzeichen sind signifikant
            Console.WriteLine($"{nameof(multilineVerbatimString)} = {multilineVerbatimString}");

            string concatenation1 = "a" + " " + "b";                    // Zusammenfügung mit "+"-Operator
            string concatenation2 = string.Format("{0} {1}", "a", "b"); // Zusammenfügung mit Methode Format() (siehe String-Interpolations-Vorschlag von ReSharper)
            string concatenation3 = $"{"a"} {"b"}";                     // Zusammenfügung mit String-Interpolation (C# 6.0, Juli 2015)
            Console.WriteLine($"{nameof(concatenation1)}: {concatenation1}");
            Console.WriteLine($"{nameof(concatenation2)}: {concatenation2}");
            Console.WriteLine($"{nameof(concatenation3)}: {concatenation3}");
        }

        [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")] // Dies Zeile entfernen und sehen, dass man utnen auf das Problem hingewiesen wird: "Return value of pure method is not used"
        private static void StringsSindUnveränderlich()
        {
            // Strings sind unveränderlich (immutable)
            string greeting = "Hello";
            greeting.Replace("Hello", "World");
            Console.WriteLine($"Ausgabe 1: {greeting}");        // Immernoch "Hello", d.h. in der obigen Zeile wurde eine neue String-Instanz erzeugt

            greeting = greeting.Replace("Hello", "World");
            Console.WriteLine($"Ausgabe 2: {greeting}");        // Jetzt hat das Ersetzen funktioniert
        }

        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantNameQualifier")]
        private static void StringVergleiche()
        {
            Console.WriteLine("--- string.IsNullOrEmpty(myString2) ---");
            string? myString2 = null;
            if (string.IsNullOrEmpty(myString2)) // Diese Abfrage wird oft benutzt, darum gibt es eine Methode dafür.
                                                 // Sonst müsste man if (myString2 == null || myString2 == "") schreiben,
                                                 // was fehleranfälliger zu schreiben und schwieriger zu lesen ist.
            {
                Console.WriteLine("Dieser String ist null oder leer.\n");
            }

            Console.WriteLine("--- string-Vergleich mit \"==\"-Operator ---");
            string myString = "";
            if (myString == string.Empty) // Der Code wird ausdrucksstärker
            {
                Console.WriteLine("Dieser String ist leer.\n");
            }

            // Im Gegensatz zu Java, funktioniert der "=="-Vergleich in C# mit dem string-Inhalt (und nicht string-Objektreferenz wie bei Java)
            //
            // Quelle: https://stackoverflow.com/questions/5204113/why-strings-does-not-compare-references (23.09.2019)
            //
            // The string type is an exception pointed out in the documentation. It is a reference type stored on the heap, but everything possible
            // has been done to make it behave like a value type. It is immutable. == compares the contents of the strings.
            //
            // For string, Uri and Version the default implementation of == is obviously not used, but instead a more specific overload is provided
            // by the framework. In fact, all of them override the == operator by implementing the public static bool operator ==.
            //
            // Quelle: https://coding.abel.nu/2014/09/net-and-equals/ (23.09.2019)
            Console.WriteLine("--- Noch ein string-Vergleich mit \"==\"-Operator (im Gegensatz zu Java funktioniert dieser Vergleich für string-Objekte) ---");
            string hans1 = "Hans";
            string hans2 = "Hans";
            if (hans1 == hans2)
            {
                Console.WriteLine($"Der Inhalt von {nameof(hans1)} und {nameof(hans2)} ist gleich.\n");
            }
            else
            {
                Console.WriteLine($"Der Inhalt von {nameof(hans1)} und {nameof(hans2)} ist _nicht_ gleich.\n");
            }

            // Weil nun der "=="-Operatior bei C# für Strings überschrieben wurde, kann man damit keine Referenzvergleiche mehr machen.
            // Will man nun doch Referenzen vergleichen (wie bei Java-Strings), muss man diese Methode object.ReferenceEquals(...) verwenden.
            // https://stackoverflow.com/questions/5204113/why-strings-does-not-compare-references
            Console.WriteLine("--- string-Referenzen mit object.ReferenceEquals() vergleichen (das Gleiche, was man bei Java mit \"==\" machen würde) ---");
            string hans3 = "Hans";
            string hans4 = "Hans";
            if (object.ReferenceEquals(hans3, hans4))
            {
                Console.WriteLine($"Die Referenz von {nameof(hans3)} und {nameof(hans4)} ist gleich.\n");

                // Wir hätten nicht erwartet, dass die Refernzen gleich sind. Sie sind es aber. Die Dokumentation sagt:
                //
                // Constant strings within the same assembly are always interned by the runtime.
                // This means they are stored in the same location in memory. Therefore, 
                // the two strings have reference equality although no assignment takes place.
                //
                // Quelle: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-test-for-reference-equality-identity (23.09.2019)
            }
            else
            {
                Console.WriteLine($"Die Referenz von {nameof(hans3)} und {nameof(hans4)} ist _nicht_ gleich.\n");
            }

            Console.WriteLine("--- Diese zwei String haben nun unterschiedliche Referenzen ---");
            string hans5 = new StringBuilder("Hans").ToString();
            string hans6 = new StringBuilder("Hans").ToString();
            if (object.ReferenceEquals(hans5, hans6))
            {
                Console.WriteLine($"Die Referenz von {nameof(hans5)} und {nameof(hans6)} ist gleich.\n");

            }
            else
            {
                // In diesem Fall mit StringBuilder sind die Referezen aber nicht mehr gleich. Die Dokumentation sagt
                //
                // A string that is created at runtime cannot be interned.
                //
                // Quelle: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-test-for-reference-equality-identity (23.09.2019)
                Console.WriteLine($"Die Referenz von {nameof(hans5)} und {nameof(hans6)} ist _nicht_ gleich.\n");
            }


            // Aber bei anderen Referenzdatentypen funktioniert es genau gleich wie bei Java, d.h.
            // der "=="-Operator vergleicht die Objektreferenzen, was oft nicht das ist, was wir wollen, und
            // der Equals-Vergleich vergleicht den Inhalt der Referenz, was oft das ist, was wir wollen
            Person hans7 = new Person { Vorname = "Hans" };
            Person hans8 = new Person { Vorname = "Hans" };

            Console.WriteLine("--- Bei Referenztypen werden (wie bei Java auch) die Referenzen werden verglichen ---");
            if (hans7 == hans8) // Referenzen werden verglichen, weil hans7 und hans8 Objekte vom Typ Person sind
            {
                Console.WriteLine($"Die Referenz von {nameof(hans7)} und {nameof(hans8)} ist gleich.\n");
            }
            else
            {
                Console.WriteLine($"Die Referenz von {nameof(hans7)} und {nameof(hans8)} ist _nicht_ gleich. ← Ungleichheit, weil nicht der Inhalt, sondern die Referenz verglichen wird.\n");
            }

            Console.WriteLine("--- Inhalte werden verglichen ---");
            if (hans7.Vorname.Equals(hans8.Vorname)) // Inhalte werden verglichen
                                                     // Weil Vorname vom Typ string ist, geht auch hans7.Vorname == hans8.vorname
            {
                Console.WriteLine($"Der Inhalt von {nameof(hans7)} und {nameof(hans8)} ist gleich.\n");
            }
            else
            {
                Console.WriteLine($"Der Inhalt von {nameof(hans7)} und {nameof(hans8)} ist _nicht_ gleich.\n");
            }
        }

        [SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Local")]
        class Person
        {
            public string Vorname { get; set; } = null!;
        }

        private static void EinigeStringMethoden()
        {
            // Einige string-Methoden
            string message = " abcde ";
            Console.WriteLine(message.Length);              // 7
            Console.WriteLine(message.Trim());              // "abcde"    // Nützlich, um Benutzereingaben zu bereinigen
            Console.WriteLine(message.ToUpper());           // " ABCDE "
            Console.WriteLine(message);                     // Wieder " abcde ", da Strings unveränderlich sind
            Console.WriteLine(message.StartsWith(" ab"));   // true
            Console.WriteLine(message.Contains("bc"));      // true
            Console.WriteLine(message.EndsWith("xy"));      // false

            // Siehe Dokumentation für String, um alle verfügbaren Methoden zu sehen
            // https://docs.microsoft.com/en-us/dotnet/api/system.string?redirectedfrom=MSDN&view=netframework-4.8
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void StringBuilderBeispiel()
        {
            // StringBuilder
            // Daumenregel: Wenn der String häufig verändert werden wird, benutze StringBuilder. Sonst String.
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            Console.WriteLine($"{nameof(sb2.Capacity)}: {sb2.Capacity} (vorher)");  // 16
            sb2.Capacity = 50;
            Console.WriteLine($"{nameof(sb2.Capacity)}: {sb2.Capacity} (nachher)"); // 50
            StringBuilder sb3 = new StringBuilder("Hallo", 50);
            Console.WriteLine(sb3.Length);      // 5
            Console.WriteLine(sb3.Capacity);    // 50
        }

        [SuppressMessage("ReSharper", "UnusedVariable")]
        private static void StringBuilderStringsVerändern()
        {
            // Strings verändern
            StringBuilder sb = new StringBuilder("Programmieren ");
            sb.Append("ist spannend?");
            sb.Insert(0, "C#-");
            sb.Replace('?', '!');               // Dokumentation der Replace-Methode lesen: replaces all occurrences
            sb.Replace("spannend", "cool");
            Console.WriteLine(sb);
            string text = sb.ToString();        // Konvertierung zu String
        }
    }
}
