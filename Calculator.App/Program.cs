using System;

namespace Calculator.App
{
    public class Program
    {
        public static void Main()
        {
            CalculationLogic.Calculator calculator = new();

            int a = 3;
            int b = 4;

            int x = calculator.Add(a, b);
            Console.WriteLine($"Das Ergebnis von {nameof(a)} und {nameof(b)} = {nameof(x)} ist:");
            Console.WriteLine($"{a} + {b} = {x}");

        }
    }
}
