namespace Übung_3_2_Translator.Translators
{
    public class EnglishTranslator : BaseTranslator
    {
        public override string TranslateWord(string word)
        {
            switch (word)
            {
                case "Tag":
                    return "day";
                case "Nacht":
                    return "night";
                default:
                    return "The word is not in the dictionary.";
            }
        }

        public override string TranslateSentence(string sentence)
        {
            switch (sentence)
            {
                case "Guten Tag.":
                    return "Good day.";
                case "Wie geht es Ihnen?":
                    return "How are you?";
                default:
                    return "The sentence is not in the dictionary.";
            }
        }
    }
}