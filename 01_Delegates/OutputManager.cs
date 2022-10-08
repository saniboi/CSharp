namespace _01_Delegates
{
    public class OutputManager
    {
        public WriteHandler Writers; // Wie eine Felddeklaration, aber für Methoden statt Daten

        public void Write(string word)
        {
            if (Writers != null)    // Siehe Vereinfachungsvorschlag von Resharper
            {
                Writers(word);
            }

            // Oder ab C# 6 (Juli 2015) besser so:
            //Writers?.Invoke(word); // https://codeblog.jonskeet.uk/2015/01/30/clean-event-handlers-invocation-with-c-6/
        }
    }
}