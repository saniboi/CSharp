using System;
using System.Diagnostics.CodeAnalysis;

namespace Übung_2_2_Überlauf
{
    public class Program
    {
        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        public static void Main()
        {
            // A)
            byte x;
            byte y;
            byte summe;

            // B)
            x = 255;
            y = 0;
            summe = (byte)(x + y);
            Console.WriteLine($"Summe kleiner als 255 wird korrekt berechnet: {x} + {y} = {summe}");

            x = 255;
            y = 1;
            summe = (byte)(x + y);
            Console.WriteLine($"Summe grösser als 255 wird falsch berechnet: {x} + {y} = {summe}");

            // C)
            // Entweder mit dem Operator checked oder indem die Überlaufkontrolle für das ganze Projekt aktiviert wird
            // Projekt: Properties → Lasche: Build → Knopf: Advanced... → Checkbox: Check for arithmetic overflow
            //checked
            //{
            //    summe = (byte)(x + y); // OverflowException wird geworfen, was gut ist, weil wir das Problem bemerken
            //}
        }
    }
}
