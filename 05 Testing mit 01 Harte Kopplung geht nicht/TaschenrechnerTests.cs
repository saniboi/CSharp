using _01_Harte_Kopplung_mit_statischen_Aufrufen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Testing_mit_01_Harte_Kopplung_geht_nicht
{
    [TestClass]
    public class TaschenrechnerTests
    {
        [TestMethod]
        public void PositiveZahlen_Addition_BerechnetSumme()
        {
            // Arrange
            var taschenrechner = new Taschenrechner();
            int erwartetesErgebnis = 7; // Ich möchte 3 und 4 eingeben als Summanden. Darum steht hier 7 als Summe.

            // Act
            taschenrechner.Addiere(); // Unittest bleibt bei der Konsole hängen und läuft nicht weiter.

            // Assert
            // Problem: Wie können wir die Eingabe beinflussen?
            //Assert.AreEqual(3, ausgabe.WertVonSummandA, "Summand A ist falsch");
            //Assert.AreEqual(4, ausgabe.WertVonSummandB, "Summand B ist falsch.");
            // Problem: Wie kommen wir an die Ausgabe heran?
            //Assert.AreEqual(erwartetesErgebnis, ausgabe.WertVonSumme, "Summe ist falsch.");
            Assert.Inconclusive();
        }
    }
}