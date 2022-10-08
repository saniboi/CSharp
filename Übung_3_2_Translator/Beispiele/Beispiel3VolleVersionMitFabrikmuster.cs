using System;
using System.Diagnostics.CodeAnalysis;
using Übung_3_2_Translator.Enums;
using Übung_3_2_Translator.Translators;

namespace Übung_3_2_Translator.Beispiele
{
    public class Beispiel3VolleVersionMitFabrikmuster
    {
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void Starte()
        {
            // Beachte: Diese Klasse kennt nur den BaseTranslator. Diese Klasse muss nicht angefasst werden, wenn wir
            //          eine neue Sprache hinzufügen

            // Optionen anzeigen
            GibOptionenAus();
            

            // Benutzerauswahl einlesen
            string languageString = Console.ReadLine();
            int languageInt = int.Parse(languageString);
            Sprache sprache = (Sprache)languageInt; // Frage: warum ist es hier überhaupt möglich etwas anderes als 1 und 2 zu cast-en?
                                                    // Antwort: ist by-design erlaubt
                                                    // Quelle: https://stackoverflow.com/questions/6413804/why-does-casting-int-to-invalid-enum-value-not-throw-exception


            // Die passenden Übersetzer instanziieren
            // Hier wurde der ganze Code, der für die Erstellung der Translator-Klassen nötig ist, in eine
            // separate Klassen ausgelagert. Der Nutzen davon ist, dass diese Beispiel3VolleVersionMitFabrikmuster.cs-Klasse
            // nicht mehr angefasst werden muss, wenn man einen neuen Translator für eine neue Sprache einführt.
            BaseTranslator translator = TranslatorFabrik.InstanziiereDenÜbersetzerFürDieSprache(sprache);


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

        /// <summary>
        /// Die Ausgabe sieht zum Beispiel so aus:
        ///
        /// Wählen Sie eine Sprache aus:
        /// 1) Englisch
        /// 2) Italienisch
        /// 
        /// </summary>
        private void GibOptionenAus()
        {
            Console.WriteLine("Wählen Sie eine Sprache aus:");
            foreach (int wert in Enum.GetValues(typeof(Sprache)))
            {
                string enumBezeichnung = Enum.GetName(typeof(Sprache), wert);
                Console.WriteLine($"{wert}) {enumBezeichnung}");
            }
        }
    }
}