using System;

namespace Übung_5_2_out_Parameter
{
    /// <summary>
    /// See documentation "Converting Equations Polar and Cartesian.pdf" to find
    /// the equations.
    /// 
    /// Note that the trigonometic function in the Math class expect angles in radians,
    /// not degrees!
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Verify values online: http://keisan.casio.com/exec/system/1223527679
        /// Verify values online: http://www.engineeringtoolbox.com/converting-cartesian-polar-coordinates-d_1347.html
        /// </summary>
        public void ConvertCoordinatesFromPolarToCartesian(double radius, double angleInDegrees, out double x, out double y)
        {
            x = radius * Math.Cos(ConvertDegreesToRadians(angleInDegrees));
            y = radius * Math.Sin(ConvertDegreesToRadians(angleInDegrees));
        }

        /// <summary>
        /// Verify values online: http://keisan.casio.com/exec/system/1223526375
        /// Verify values online: http://www.engineeringtoolbox.com/converting-cartesian-polar-coordinates-d_1347.html
        /// </summary>
        public void ConvertCoordinatesFromCartesianToPolar(double x, double y, out double radius, out double angleInDegrees)
        {
            radius = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            angleInDegrees = ConvertRadiansToDegrees(Math.Atan2(y, x));
        }

        /// <summary>
        /// http://www.rapidtables.com/convert/number/degrees-to-radians.htm
        /// </summary>
        /// <param name="angleInDegrees">value in degrees</param>
        /// <returns>Value in radians</returns>
        private double ConvertDegreesToRadians(double angleInDegrees)
        {
            return angleInDegrees * Math.PI / 180;
        }

        /// <summary>
        /// http://www.rapidtables.com/convert/number/radians-to-degrees.htm
        /// </summary>
        /// <param name="angleInRadians">Value in radians</param>
        /// <returns>Value in degrees</returns>
        private double ConvertRadiansToDegrees(double angleInRadians)
        {
            return angleInRadians * 180 / Math.PI;
        }
    }
}