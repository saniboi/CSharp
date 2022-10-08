namespace _13_Klassenelemente_Statische_Methoden
{
    public class Elektrizität
    {
        /// <summary>
        /// Formel: p = u * i
        /// </summary>
        /// <param name="u">u = Spannung [Volt]</param>
        /// <param name="i">i = Stromstärke [Ampere]</param>
        /// <returns>p = Elektrische Leistung [Watt]</returns>
        public static double BerechneLeistung(double u, double i)
        {
            return u * i;
        }
    }
}