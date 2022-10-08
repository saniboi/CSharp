using System.Diagnostics.CodeAnalysis;

namespace _01_Delegates
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
                    DelegateHelloWorldBeispiel();
                    break;
                case 2:
                    DelegateBeispielAusDenFolien();
                    break;
            }
        }

        #region Einfaches Beispiel

        // Ein Delegate ist eine Referenz auf eine Methode.
        // Ein Delegate ist ein Typ wie eine Klasse;
        // Siehe dazu die Deklaration unten mit
        // var writer = new Writer(fileLogger.WriteMessage);
        public delegate void Writer(string message);

        private static void DelegateHelloWorldBeispiel()
        {
            var fileLogger = new FileLogger();

            // Hier hängen wir eine erste Methode an den writer-Delegaten.
            //
            // Beachte, dass WriteMessage hier
            // nicht ausgeführt wird; darum auch
            // keine runden Klammern hinter WriteMessage().
            //
            // fileLogger.WriteMessage geben wir hier als Argument mit,
            // damit writer darauf zeigen kann: writer → fileLogger.WriteMessage
            var writer = new Writer(fileLogger.WriteMessage);

            // Interpretation: writer ist ein Funktionszeiger und zeigt auf die Methode
            // fileLogger.WriteMessage(string message).
            //
            // Wenn writer("Test") aufgerufen wird, wird fileLogger.WriteMessage("Test") ausgeführt.
            //
            // Wenn oben "Writer writer = null" wäre, käme hier eine NullReferenceExeption.
            // Das ist später bei den Events relevant, wo ein null-Check gemacht werden muss.
            Console.WriteLine("--- Erster write-Aufruf ruft fileLogger.WriteMessage(...) auf ---");
            writer("Erster Log-Eintrag"); // writer("Test") → fileLogger.WriteMessage("Test")
            Console.WriteLine("--- Ende ---");

            // Nun hängen wir noch eine zweite Methode an den writer-Delegaten
            var emailLogger = new EmailLogger();
            writer += new Writer(emailLogger.WriteMessage);
            //writer = null;
            Console.WriteLine("\n--- Zweiter write-Aufruf ruft fileLogger.WriteMessage(...) _und_ emailLogger.WriteMessage auf ---");
            writer("Zweiter Log-Eintrag");
            Console.WriteLine("--- Ende ---");
        }

        public class FileLogger
        {
            public void WriteMessage(string message)
            {
                Console.WriteLine($"In Log-Datei schreiben: '{message}'"); // Hier käme der Code hin, der in eine Log-Datei schreiben würde
            }
        }

        public class EmailLogger
        {
            public void WriteMessage(string message)
            {
                Console.WriteLine($"E-Mail senden mit: {message}"); // Hier käme der Code hin, der eine E-Mail verwenden würde
            }
        }

        #endregion

        #region Beispiel aus den Folien

        private static void DelegateBeispielAusDenFolien()
        {
            OutputManager outputManager = new OutputManager();
            EnglishWriter englishWriter = new EnglishWriter();
            ItalianWriter italianWriter = new ItalianWriter();

            //outputManager.Writers = new WriteHandler(italianWriter.OnWrite);  // Ohne "+" wird einfach ein Handler gesetzt (und ggf. vorher gesetzte überschreiben)
            //outputManager.Writers = new WriteHandler(englishWriter.OnWrite);  // Ohne "+" wird einfach ein Handler gesetzt (und ggf. vorher gesetzte überschreiben)
            outputManager.Writers += new WriteHandler(italianWriter.OnWrite);   // new WriteHandler kann man weglassen, weil der Compiler es ableiten kann
            outputManager.Writers += new WriteHandler(englishWriter.OnWrite);
            outputManager.Writers += new WriteHandler(englishWriter.OnWrite);   // Man kann auch den gleichen Handler mehrfach anhängen
            //outputManager.Writers -= new WriteHandler(englishWriter.OnWrite); // Entfernt wieder einen EnglishWriter-Handler
            //outputManager.Writers = new WriteHandler(englishWriter.OnWrite);  // Ohne "+" würde die anderen Handler überschreiben

            string word = "Tag";
            Console.WriteLine($"--- Write(\"{word}\") ---");
            outputManager.Write(word);

            word = "Nacht";
            Console.WriteLine($"\n--- Write(\"{word}\") ---");
            outputManager.Write(word);

            word = "Nacht";
            Console.WriteLine($"\n--- Write(\"{word}\") ---");
            outputManager.Writers -= new WriteHandler(englishWriter.OnWrite); // Entfernt wieder einen EnglishWriter-Handler
            outputManager.Write(word);
        }

        #endregion
    }
}