using System;

namespace Übung_3_4_IComparable
{
    public class Temperatur : IComparable
    {
        private double temperaturInKelvin;

        public double Kelvin
        {
            get
            {
                return temperaturInKelvin;              // Expression-body-Syntax mit ReSharper anzeigen lassen
            }
            set
            {
                temperaturInKelvin = value;
            }
        }

        public double Celsius
        {
            get
            {
                return temperaturInKelvin - 273.15;
            }
            set
            {
                temperaturInKelvin = value + 273.15;
            }
        }

        public double Fahrenheit
        {
            get
            {
                return Celsius * 1.8 + 32;
            }
            set
            {
                temperaturInKelvin = (value - 32) / 1.8 + 273.15;
            }
        }

        public int CompareTo(object obj)
        {
            // Diesen Block braucht es nur, wenn man die Übung 4.1 Exception in
            // die Übung 3.4 IComparable einbaut
            bool istObjektVomTypTemperatur = obj is Temperatur;
            if (!istObjektVomTypTemperatur)
            {
                throw new ArgumentException($"Argument {nameof(obj)} ist nicht vom Typ Temperatur!");
            }

            Temperatur temperatur = (Temperatur)obj;
            return temperaturInKelvin.CompareTo(temperatur.temperaturInKelvin); // Wir können einfach die existierende CompareTo-Methode von
                                                                                // double wiederverwenden.

            // Die Alternative wäre es gewesen, den Vergleichscode nochmals
            // selber wie folgt zu implementieren, aber das wäre Zeitverschwendung
            //if (Kelvin > temperatur.Kelvin) return 1;
            //if (Kelvin < temperatur.Kelvin) return -1;
            //return 0; // if (Kelvin == temperatur.Kelvin) return 0;
        }
    }
}