using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    /// <summary>
    /// Beachte am Schluss des Programmierens (hier sind nur die Vorteile aufgelistet; für Nachteile siehe Folien):
    /// 
    /// 1. Wir haben mit den Äquivalenzklassen-Methode an Fälle gedacht, an die wir sonst nicht gedacht haben
    /// 2. Wir haben Tippfehler gefunden, die wir sonst erst später gefunden hätten, wenn überhaupt: Beispiel return addendA + addendA;
    /// 3. Wir haben uns bewusst Klassen-Design-Überlegungen gemacht
    /// 4. Wir haben lebende Dokumentation erstellt
    /// 5. Wir haben ein Auffangnetz erhalten, welches uns ein sicheres Gefühl für Anpassungen gibt
    /// 6. Wir haben uns eine Schicht unterhalb des UIs eingehängt mit unseren Tests:
    ///     Vorteil: einfachere Testautomatisierung
    ///     Nachteil: Logik aus der UI-Schicht wurde nicht getestet; da muss man automatisierte UI-Tests schreiben oder manuell Testen
    ///
    /// Im Projektteam
    /// - Wenn ich aus Versehen Code der Kollegen kaputt mache, werde ich das rasch merken
    /// 
    /// Sonstiges
    /// - ReSharper: Ctrl+U, Ctrl+U = Repeat previous run
    /// - Visual Studio: Ctrl+R,L = Repeat last run
    /// - Wir haben MSTest verwendet; es gibt andere Unit-Testing-Frameworks: https://www.google.com/search?q=c%23+unit+testing+frameworks
    /// - Siehe auch https://en.wikipedia.org/wiki/List_of_unit_testing_frameworks#.NET_programming_languages
    /// - Siehe auch https://fluentassertions.com/
    /// </summary>
    [TestClass]
    public class RechenoperationenTests
    {
        private CalculationLogic.Calculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            calculator = new CalculationLogic.Calculator();
        }

        [TestMethod]
        public void PositiveZahlen_Addieren_RetourniertSumme() // Given-when-then-Syntax
        {
            // Tripple A pattern

            // Arrange
            //var calculator = new Calculator();
            int expectedResult = 5; // Erwartetes Ergebnis

            // Act
            int actualResult = calculator.Add(2, 3); // Tatsächliches Ergebnis

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void NegativeZahlen_Addieren_RetourniertSumme()
        {
            // Arrange
            //var calculator = new Calculator();
            int expectedSum = -3;

            // Act
            double actualSum = calculator.Add(-1, -2);

            // Assert
            Assert.AreEqual(expectedSum, actualSum); // MSTest-API
            actualSum.Should().Be(expectedSum);      // FluentAssertions-API
        }

        [TestMethod]
        public void ZahlPlusNull_Addieren_RetourniertUrsprünglicheZahl()
        {
            // Arrange
            //var calculator = new Calculator();
            int expectedSum = 2;

            // Act
            double actualSum = calculator.Add(2, 0);

            // Assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))] // Assert
        public void DivisorIstNull_Dividieren_WirftException()
        {
            // Arrange
            //var calculator = new Calculator();

            // Act
            int actualResult = calculator.Divide(3, 0);

            // Assert
            // Kein Assert hier, sondern ExpectedException-Attribut oben
        }

        // TODO: Tests für Subtraktion hinzufügen
        // TODO: Tests für Division hinzufügen
        // TODO: Tests für Multiplikation hinzufügen
    }
}
