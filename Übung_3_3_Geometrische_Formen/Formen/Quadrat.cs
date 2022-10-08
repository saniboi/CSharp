using System;

namespace Übung_3_3_Geometrische_Formen.Formen
{
    public class Quadrat : IForm
    {
        public double Umfang
        {
            get { return 4*Seitenlänge; }
        }

        public double Seitenlänge { get; set; }

        public Quadrat(double seitenlänge)
        {
            Seitenlänge = seitenlänge;
        }

        public double BerechneFläche()
        {
            return Math.Pow(Seitenlänge, 2);
        }

        public override string ToString()
        {
            return $"Quadrat(Seitenlänge:{Seitenlänge})";
        }
    }
}