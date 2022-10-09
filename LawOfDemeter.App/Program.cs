using System;

namespace LawOfDemeter.App
{
    public class Program
    {
        public static void Main()
        {
            new A().GetB().GetC(); // Law of Demeter missachtet

            // Dieser Verkettung der Methodenaufrufe führt dazu, dass aus der obersten Schicht
            // LawOfDemeter.App eine Referenz auf die unterste Schicht LawOfDemeter.DAL
            // erstellt werden muss, was der Schichtenarchitektur widerspricht.
            //
            // https://de.wikipedia.org/wiki/Gesetz_von_Demeter
            
            Console.WriteLine("Ende.");
        }
    }
}