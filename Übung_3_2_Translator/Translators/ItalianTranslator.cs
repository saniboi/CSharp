namespace Übung_3_2_Translator.Translators
{
    public class ItalianTranslator : BaseTranslator
    {
        public override string TranslateWord(string word)
        {
            switch (word)
            {
                case "Tag":
                    return "giorno";
                case "Nacht":
                    return "notte";
                default:
                    return "The word is not in the dictionary.";
            }
        }

        public override string TranslateSentence(string sentence)
        {
            switch (sentence)
            {
                case "Guten Tag.":
                    return "Buon giorno.";
                case "Wie geht es Ihnen?":
                    return "Come sta?";
                default:
                    return "The sentence is not in the dictionary.";
            }
        }
    }
}