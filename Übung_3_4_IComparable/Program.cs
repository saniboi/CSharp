namespace Übung_3_4_IComparable
{
    public class Program
    {
        public static void Main()
        {
            TestTreiber testTreiber = new TestTreiber();

            // Version 1: Zwischenlösung mit zwei Elementen (zuerst das kleinere Problem lösen)
            testTreiber.VergleicheZweiTemperaturwerteMiteinander();

            // Version 2: Finale Lösung mit beliebig vielen Elementen (am Schluss das grosse Problem lösen)
            testTreiber.Sortiere10TemperaturwerteAufsteigend();
        }
    }
}