using System;

namespace Übung_3_4_IComparable
{
    public class TestTreiber
    {
        public void VergleicheZweiTemperaturwerteMiteinander()
        {
            Console.WriteLine("--- VergleicheZweiTemperaturwerteMiteinander() ---");

            Temperatur temperatur1 = new Temperatur { Celsius = 0 };
            Temperatur temperatur2 = new Temperatur { Kelvin = 0 };

            int ergebnisVonCompareTo = temperatur1.CompareTo(temperatur2);

            switch (ergebnisVonCompareTo)
            {
                // Hier wäre ein Enum nützlich, um die magischen Zahlen wegzukriegen.
                // Ich belasse aber die Zahlen, weil wir aus der Interface-Dokumentation wissen,
                // wie IComparable vergleicht und genau das mit 1, -1 und 0 hier in diesem
                // Schulungsbeispiel demonstrieren wollen.
                case 1:
                    Console.WriteLine($"temperature1 mit {temperatur1.Celsius}°C ist höher als temperatur2 mit {temperatur2.Celsius}°C.");
                    break;
                case -1:
                    Console.WriteLine($"temperature1 mit {temperatur1.Celsius}°C ist tiefer als temperatur2 mit {temperatur2.Celsius}°C.");
                    break;
                case 0:
                    Console.WriteLine($"Beide Temperaturwerte temperatur1 mit {temperatur1.Celsius}°C und temperatur2 mit {temperatur2.Celsius}°C sind gleich.");
                    break;
            }
        }

        public void Sortiere10TemperaturwerteAufsteigend()
        {
            Console.WriteLine("\n--- VergleicheZweiTemperaturwerteMiteinander() ---");

            Temperatur[] listeVonTemperaturwerten = new Temperatur[10];
            listeVonTemperaturwerten[0] = new Temperatur { Celsius = -13 };
            listeVonTemperaturwerten[1] = new Temperatur { Celsius = -12 };
            listeVonTemperaturwerten[2] = new Temperatur { Celsius = -11 };
            listeVonTemperaturwerten[3] = new Temperatur { Celsius = -10 };
            listeVonTemperaturwerten[4] = new Temperatur { Kelvin = 0 }; // = -273.15
            listeVonTemperaturwerten[5] = new Temperatur { Kelvin = 1 };
            listeVonTemperaturwerten[6] = new Temperatur { Kelvin = 2 };
            listeVonTemperaturwerten[7] = new Temperatur { Fahrenheit = 32 }; // = 0°C
            listeVonTemperaturwerten[8] = new Temperatur { Fahrenheit = 33 };
            listeVonTemperaturwerten[9] = new Temperatur { Fahrenheit = 34 };

            //// Man kann auch so alle Datenfelder instanziieren
            //for (int i = 0; i < listeVonTemperaturwerten.Length; ++i)
            //{
            //    listeVonTemperaturwerten[i] = new Temperatur();
            //}
            //listeVonTemperaturwerten[0].Celsius = -13;
            //// ...
            //listeVonTemperaturwerten[4].Kelvin = 0; // = -273.15
            //// ...

            Array.Sort(listeVonTemperaturwerten);

            // Diesen Block braucht es nur, wenn man die Übung 4.1 Exception in
            // die Übung 3.4 IComparable einbaut
            //try
            //{
            //    Array.Sort(listeVonTemperaturwerten);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}

            for (int index = 0; index < listeVonTemperaturwerten.Length; index++)
            {
                //TemperaturwerteAusgeben_EineLangeConsoleWriteLineZeile(index, listeVonTemperaturwerten);
                //TemperaturwerteAusgeben_LesbarereVariante(index, listeVonTemperaturwerten);
                TemperaturwerteAusgeben_MitAusgabeformatierung(index, listeVonTemperaturwerten);
            }
        }

        private static void TemperaturwerteAusgeben_EineLangeConsoleWriteLineZeile(int index, Temperatur[] listeVonTemperaturwerten)
        {
            Console.WriteLine($"Temperaturwert[{index}]: {listeVonTemperaturwerten[index].Kelvin}°K = {listeVonTemperaturwerten[index].Celsius}°C = {listeVonTemperaturwerten[index].Fahrenheit}°F");
        }

        private void TemperaturwerteAusgeben_LesbarereVariante(int index, Temperatur[] listeVonTemperaturwerten)
        {
            //Console.WriteLine($"Temperaturwert[{index}]: {listeVonTemperaturwerten[index].Kelvin}°K = {listeVonTemperaturwerten[index].Celsius}°C = {listeVonTemperaturwerten[index].Fahrenheit}°F");

            // Wenn die erste Variante, wegen den langen Variablen- und Eigenschaftsnamen zu lang ist,
            // kann man den Code auch folgendermassen schreiben, um ihn leserlicher zu machen.
            
            // Neue kurze Variablennamen einführen, die nur innerhalb der Methode gültig sind;
            // Weil der Gültigkeitsbereich sehr klein ist und klar ist was, k, c und f bedeuten, sind die
            // Variablennamen ok.
            double k = listeVonTemperaturwerten[index].Kelvin;
            double c = listeVonTemperaturwerten[index].Celsius;
            double f = listeVonTemperaturwerten[index].Fahrenheit;

            Console.WriteLine($"Temperaturwert[{index}]: {k}°K = {c}°C = {f}°F");
        }

        private static void TemperaturwerteAusgeben_MitAusgabeformatierung(int index, Temperatur[] listeVonTemperaturwerten)
        {
            double k = listeVonTemperaturwerten[index].Kelvin;
            double c = listeVonTemperaturwerten[index].Celsius;
            double f = listeVonTemperaturwerten[index].Fahrenheit;

            Console.WriteLine($"Temperaturwert[{index}]: {k,7:F2}°K = {c,7:F2}°C = {f,7:F2}°F");
        }
    }
}