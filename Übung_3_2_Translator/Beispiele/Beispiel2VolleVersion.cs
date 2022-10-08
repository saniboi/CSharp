using System;
using System.Diagnostics.CodeAnalysis;
using Übung_3_2_Translator.Enums;
using Übung_3_2_Translator.Translators;

namespace Übung_3_2_Translator.Beispiele
{
    public class Beispiel2VolleVersion
    {
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Starte()
        {
            // Optionen anzeigen
            Console.WriteLine("Wählen Sie eine Sprache aus:");
            Console.WriteLine("1) Englisch");
            Console.WriteLine("2) Italienisch");

            // Benutzerauswahl einlesen
            string languageString = Console.ReadLine();
            int languageInt = int.Parse(languageString);
            Sprache sprache = (Sprache)languageInt;

            // Abhängig von der Benutzerauswahl den richtigen Translator instanziieren
            BaseTranslator translator = null;
            switch (sprache)
            {
                case Sprache.Englisch:
                    translator = new EnglishTranslator();
                    break;
                case Sprache.Italienisch:
                    translator = new ItalianTranslator();
                    break;
                default:
                    Console.WriteLine($"Nur 1 und 2 sind gültige Eingaben. Sie haben {sprache} eingegeben.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("--- Übersetzungen ---");
            if (translator != null)
            {
                // Ein paar Beispielwörter übersetzen
                Console.WriteLine($"Tag = {translator.TranslateWord("Tag")}");
                Console.WriteLine($"Nacht = {translator.TranslateWord("Nacht")}");

                // Ein paar Beispielsätze übersetzen
                Console.WriteLine($"Guten Tag = {translator.TranslateSentence("Guten Tag.")}");
                Console.WriteLine($"Wie geht es Ihnen? = {translator.TranslateSentence("Wie geht es Ihnen?")}");
            }
        }
    }
}