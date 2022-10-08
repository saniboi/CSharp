namespace _04_Eigene_Exception
{
    public class Program
    {
        public static void Main()
        {
            throw new InvalidesDatumsformat("...Meine möglichst detaillierte Fehlermeldung...");

            //throw new Program(); // Geht nicht
            // Compiler sagt: The type caught or thrown must be derived from System.Exception
        }
    }

    /// <summary>
    /// Das ist eine minimale Implementierung einer eigenen Exception-Klasse.
    /// Alle Konstruktoren reichen die Aufgaben weiter and die Basisklasse.
    /// Der einzige aktuelle Nutzen dieser eigenen Exception-Klasse ist, dass ich nun
    /// in meinem Programm diese sprechende Exception werfen, fangen und entsprechend
    /// abhandeln kann.
    /// </summary>
    internal class InvalidesDatumsformat : Exception
    {
        public InvalidesDatumsformat() { }
        public InvalidesDatumsformat(string message) : base(message) { }
        public InvalidesDatumsformat(string message, Exception innerException) : base(message, innerException) { }
    }
}