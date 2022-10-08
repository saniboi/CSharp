using System;
using System.Diagnostics.CodeAnalysis;
using Übung_3_2_Translator.Translators;

namespace Übung_3_2_Translator.Beispiele
{
    public class Beispiel1MinimaleVersion
    {
        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        public void Starte()
        {
            // Teil 1/2: Diesen Teil des Codes müssen wir immer anfassen, wenn wir eine neue Sprache hinzufügen
            BaseTranslator translator;           // Wir programmieren immer gegen BaseTranslator
            translator = new EnglishTranslator();       // Aber je nach Bedarf verwenden wir eine andere Implementation
            //translator = new ItalianTranslator();     // Aber je nach Bedarf verwenden wir eine andere Implementation
            //translator = new XYZTranslator();         // Der grosse Vorteil kommt zum Zug,
                                                        // wenn ich eine neue Sprache einbauen will.
                                                        // Das geht indem ich eine neue Klasse implementiere
                                                        // und im bestehenden Code muss ich genau eine Zeile ändern.
                                                        // Der ganze Rest des bestehenden Codes kann ich unangetastet lassen!



            // Teil 2/2: Diesen Teil des Codes müssen wir nicht mehr anfassen. Insbesondere auch nicht, wenn wir eine
            //           neue Sprache hinzufügen
            Console.WriteLine($"Tag = {translator.TranslateWord("Tag")}");
            Console.WriteLine($"Guten Tag. = {translator.TranslateSentence("Guten Tag.")}\n");
        }
    }
}