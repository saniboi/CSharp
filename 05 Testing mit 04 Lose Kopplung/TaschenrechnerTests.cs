using _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface;
using _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Ausgabe;
using _04_Lose_Kopplung_mit_new_ausserhalb_der_Klasse_plus_Interface.Eingabe;
using _05_Testing_mit_04_Lose_Kopplung.Ausgabe;
using _05_Testing_mit_04_Lose_Kopplung.Eingabe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace _05_Testing_mit_04_Lose_Kopplung
{
    [TestClass]
    public class TaschenrechnerTests
    {
        /// <summary>
        /// Alle Mocks werden von Hand implementiert.
        /// </summary>
        [TestMethod]
        public void PositiveZahlen_Addition_BerechnetSumme()
        {
            // Arrange

            // Den Platzhalter für die Eingabe vorbereiten
            IEingabe mockEingabe = new KonsolenEingabePlatzhalter();
            KonsolenEingabePlatzhalter eingabe = (KonsolenEingabePlatzhalter)mockEingabe;
            eingabe.RückgabewertFürDenErstenMethodenAufruf = 3;
            eingabe.RückgabewertFürDenZweitenMethodenAufruf = 4;

            // Den Platzhalter für die Ausgabe vorbereiten
            IAusgabe mockAusgabe = new KonsolenAusgabePlatzhalter();
            KonsolenAusgabePlatzhalter ausgabe = (KonsolenAusgabePlatzhalter) mockAusgabe;

            // Den erwarteten Wert vorbereiten
            int erwartetesErgebnis = 7;

            // Die Klasse zum Testen vorbereiten
            Taschenrechner taschenrechner = new Taschenrechner(mockEingabe, mockAusgabe);

            // Act
            taschenrechner.Addiere();

            // Assert
            Assert.AreEqual(3, ausgabe.WertVonSummandA, "Summand A ist falsch");
            Assert.AreEqual(4, ausgabe.WertVonSummandB, "Summand B ist falsch.");
            Assert.AreEqual(erwartetesErgebnis, ausgabe.WertVonSumme, "Summe ist falsch.");
        }

        /// <summary>
        /// Alle Mocks lassen wir von Moq automatisch erstellen.
        ///
        /// Im Moment sieht es nicht nach einem Mehrwert aus, weil beide Codeblöcke etwa gleich gross sind.
        ///
        /// Wenn wir aber weitere Tests schreiben, wird es mit Moq weniger Programmieraufwand bedeuten.
        /// 
        /// https://github.com/moq/moq4
        /// </summary>
        [TestMethod]
        public void PositiveZahlen_Addition_BerechnetSumme_MitMoqBibliothek()
        {
            // Arrange

            // Den Platzhalter für die Eingabe vorbereiten
            Mock<IEingabe> mockEingabe = new Mock<IEingabe>();
            mockEingabe.SetupSequence(mock => mock.LiesZahlEin())
                .Returns(3)
                .Returns(4);

            // Den Platzhalter für die Ausgabe vorbereiten
            Mock<IAusgabe> mockAusgabe = new Mock<IAusgabe>();
            int wertVonSummandA = 0;
            int wertVonSummandB = 0;
            int wertVonSumme = 0;
            mockAusgabe.Setup(mock => mock.GibSummeAus(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Callback((int a, int b, int summe) =>
                {
                    wertVonSummandA = a;
                    wertVonSummandB = b;
                    wertVonSumme = summe;
                });

            // Den erwarteten Wert vorbereiten
            int erwartetesErgebnis = 7;

            // Die Klasse zum Testen vorbereiten
            Taschenrechner taschenrechner = new Taschenrechner(mockEingabe.Object, mockAusgabe.Object);

            // Act
            taschenrechner.Addiere();

            // Assert
            Assert.AreEqual(3, wertVonSummandA, "Summand A ist falsch");
            Assert.AreEqual(4, wertVonSummandB, "Summand B ist falsch.");
            Assert.AreEqual(erwartetesErgebnis, wertVonSumme, "Summe ist falsch.");
        }
    }
}