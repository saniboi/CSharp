using System;

namespace _03_Methoden_überschreiben.Entitäten
{
    internal class Basisklasse
    {
        public virtual void SagHallo(string name)
        {
            Console.WriteLine($"Basisklasse: Hello, {name}!");
        }
    }
}