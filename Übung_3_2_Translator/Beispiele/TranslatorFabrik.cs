using System;
using Übung_3_2_Translator.Enums;
using Übung_3_2_Translator.Translators;

namespace Übung_3_2_Translator.Beispiele
{
    // Eine Fabrik (factory) ist ein Entwurfsmuster: https://de.wikipedia.org/wiki/Fabrikmethode
    internal class TranslatorFabrik
    {
        // Diese Fabrikmethode übernimmt das erzeugen der Objekte mit dem Schlüsselwort "new"
        public static BaseTranslator InstanziiereDenÜbersetzerFürDieSprache(Sprache sprache)
        {
            switch (sprache)
            {
                case Sprache.Englisch:
                    return new EnglishTranslator();
                case Sprache.Italienisch:
                    return new ItalianTranslator();
                default:
                    Console.WriteLine($"Nur 1 und 2 sind gültige Eingaben. Sie haben aber {sprache} eingegeben.");
                    return null;
            }
        }
    }
}