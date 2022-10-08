using System.Diagnostics.CodeAnalysis;

namespace _09_Methoden_mehrere_Rückgabewerte
{
    internal class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 1;

            switch (beispiel)
            {
                case 1:
                    Lösung1MitObjekt();
                    break;
                case 2:
                    Lösung2MitArray();
                    break;
                case 3:
                    Lösung3MitOutParameter();
                    break;
                case 4:
                    Lösung4MitRefParameter();
                    break;
            }
        }

        #region Lösung1MitObjekt

        private static void Lösung1MitObjekt()
        {
            Koordinaten koordinaten = PolarZuKarthesisAlsKlasse(1, 2);
            Console.WriteLine($"Lösung 1: {koordinaten}");
        }

        public static Koordinaten PolarZuKarthesisAlsKlasse(int radius, int winkel)
        {
            var koordinaten = new Koordinaten();
            koordinaten.X = radius * Math.Cos(winkel);
            koordinaten.Y = radius * Math.Sin(winkel);
            return koordinaten;
        }

        internal class Koordinaten
        {
            public double X { get; set; }
            public double Y { get; set; }

            public override string ToString()
            {
                return $"Koordinaten: X = {X}, Y = {Y}";
            }
        }

        #endregion

        #region Lösung2MitArray

        /// <summary>
        /// Lösung 2 ist nicht so gut wie Lösung 1, weil die beiden Werte
        /// koordinaten[0] und koordinaten[1] nicht sprechend sind.
        /// Zudem müssen sie vom gleichen Typ sein.
        /// </summary>
        private static void Lösung2MitArray()
        {
            double[] koordinaten = PolarZuKarthesisAlsArray(1, 2);
            Console.WriteLine($"Lösung 2: Koordinaten: X = {koordinaten[0]}, Y = {koordinaten[1]}");
        }

        private static double[] PolarZuKarthesisAlsArray(int radius, int winkel)
        {
            var koordination = new double[2];
            koordination[0] = radius * Math.Cos(winkel);
            koordination[1] = radius * Math.Sin(winkel);
            return koordination;
        }

        #endregion

        #region Lösung3MitOutParameter

        private static void Lösung3MitOutParameter()
        {
            double x;
            double y;
            PolarToKartesischAlsOutParameter(1, 2, out x, out y);
            Console.WriteLine($"Lösung 3: Koordinaten: X = {x}, Y = {y}");
        }

        private static void PolarToKartesischAlsOutParameter(int radius, int winkel, out double x, out double y)
        {
            x = radius * Math.Cos(winkel);
            y = radius * Math.Sin(winkel);
        }

        #endregion

        #region Lösung4MitRefParameter

        public static void Lösung4MitRefParameter()
        {
            double x = 0;
            double y = 0;
            PolarToKartesischAlsRefParameter(1, 2, ref x, ref y);
            Console.WriteLine($"Lösung 4: Koordinaten: X = {x}, Y = {y}");
        }

        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private static void PolarToKartesischAlsRefParameter(int radius, int winkel, ref double x, ref double y)
        {
            x = radius * Math.Cos(winkel);
            y = radius * Math.Sin(winkel);
        }

        #endregion
    }
}