using System;

namespace Übung_5_2_out_Parameter
{
    public class TestTreiber
    {
        private readonly Converter converter;
        private double resultXFromFirstCalculation;
        private double resultYFromFirstCalculation;

        public TestTreiber()
        {
            converter = new Converter();
        }

        public void ConvertPolarToCartesian()
        {
            Console.WriteLine("--- Polar to cartesian ---");
            double radius = 85.3;
            double angleInDegrees = 22.3;
            double x;
            double y;
            converter.ConvertCoordinatesFromPolarToCartesian(radius, angleInDegrees, out x, out y);
            Console.WriteLine($"radius = {radius}, angle = {angleInDegrees}° ==> x = {x}, y = {y}");

            resultXFromFirstCalculation = x;
            resultYFromFirstCalculation = y;
        }

        public void ConvertCartesianToPolar()
        {
            Console.WriteLine("\n--- Cartesian to polar ---");
            double x = resultXFromFirstCalculation;
            double y = resultYFromFirstCalculation;
            double radius;
            double angleInRadians;
            converter.ConvertCoordinatesFromCartesianToPolar(x, y, out radius, out angleInRadians);
            Console.WriteLine($"x = {x}, y = {y} ==> radius = {radius}, angle = {angleInRadians}°");
            Console.WriteLine();
        }
    }
}