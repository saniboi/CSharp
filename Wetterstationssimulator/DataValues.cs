using System;
namespace Wetterstationssimulator
{
    public class DataValues
    {
        public DateTime DateTime { get; set; }
        public double Temperature { get; set; }
        public int WindSpeed { get; set; }
        public int Rainfall { get; set; }
        public int ProbabilityOfPrecipitation { get; set; }
        public int Humidity { get; set; }

    }
}
