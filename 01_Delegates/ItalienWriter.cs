namespace _01_Delegates
{
    public class ItalianWriter
    {
        private readonly IDictionary<string, string> dictionary;

        public ItalianWriter()
        {
            dictionary = new Dictionary<string, string>();
            dictionary["Tag"] = "giorno";
            dictionary["Nacht"] = "notte";
        }

        public void OnWrite(string word) // Namenskonvention mit OnXxx
        {
            Console.WriteLine(dictionary[word]);
        }
    }
}