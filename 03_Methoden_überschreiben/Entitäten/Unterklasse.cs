using System;

namespace _03_Methoden_überschreiben.Entitäten
{
    internal class Unterklasse : Basisklasse
    {
        public override void SagHallo(string name)  // Hier wird die Methode der Basisklasse
            // mit der gleichen Signatur _überschrieben_.
        {
            Console.WriteLine($"Unterklasse: Hello, {name}!");
        }
    }
}