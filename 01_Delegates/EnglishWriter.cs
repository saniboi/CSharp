namespace _01_Delegates
{
    public class EnglishWriter
    {
        private readonly IDictionary<string, string> dictionary;

        public EnglishWriter()
        {
            dictionary = new Dictionary<string, string>();
            dictionary["Tag"] = "day";
            dictionary["Nacht"] = "night";
        }

        public void OnWrite(string word) // Namenskonvention mit OnXxx
        {
            Console.WriteLine(dictionary[word]);
        }
    }
}