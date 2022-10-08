using System;

namespace Übung_3_3_Geometrische_Formen.Formen
{
    public class Kreis : IForm
    {
        /// <summary>
        /// Formel: U = 2·π·r
        /// </summary>
        public double Umfang
        {
            get { return 2*Math.PI*Radius; }
        }

        public double Radius { get; set; }

        public Kreis(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Formel: A = π·r2 = π·r·r (r im Quadrat)
        /// </summary>
        public double BerechneFläche()
        {
            return Math.PI*Math.Pow(Radius, 2);
        }

        public override string ToString()
        {
            return $"Kreis(radius:{Radius})";
        }
    }
}