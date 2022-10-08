namespace _01_Kommentare
{
    public class Program
    {
        /// <summary>
        /// (1/4)
        /// Das ist ein Methodenkommentar (fahre mit der Maus über den Methodennamen "Main" und siehe Tooltip)
        /// Schreibt hier das Warum (nicht das Wie) rein: Gründe, Kontext, Begründung, Konzepte, Rahmenbedingungen usw.
        /// </summary>
        /// <param name="args">Die Parameter, die der Applikation von der Konsole übergeben werden  (fahre mit der Maus über den Parametername "args" und siehe Tooltip)</param>
        public static void Main(string[] args)
        {
            // (2/4)
            // Das ist ein Kommentar, der sich auf den Block bezieht
            Console.WriteLine("Hello, World 1!"); // Dies ist ein Kommentar, der sich auf die Zeile bezieht
            Console.WriteLine("Hello, World 2!"); // Dies ist ein Kommentar, der sich auf die Zeile bezieht

            // (3/4)
            /*
                Das ist
                ein mehrzeiliger
                Kommentar
            */

            // So ist es üblicher:
            // Das ist
            // ein mehrzeiliger
            // Kommentar

            // (4/4)
            Console.WriteLine(/* Hier eine weitere Möglichkeit */ "Hello, World 3!");
        }



        // Tipp für jetzt:  Kommententiert all euren Code möglichst viel als Dokumentation, damit ihr später noch wisst, was ihr überlegt habt und wie der Code funktioniert.
        // Tipp für später: Kommentiert möglichst wenig und schreibt klaren und selbsterklärenden Code.
    }
}