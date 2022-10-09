using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prämienrechner.Model;

namespace Prämienrechner.Unittests
{
    [TestClass]
    public class TestKlasse
    {
        #region Testing 1

        [TestMethod]
        public void Praemienberechnung1()
        {
            //Arrange Der Versicherungsnehmer wählt die Franchise 300 und Versicherungsmodell keine
            string franchise = "300";
            string vModell = "Keine";

            // Act Die Monatsprämie wird berechnet
            double aktuell = Person.GetMonatsPraemie(franchise, vModell);

            // Assert Die erwartete Ergebnis ist: Monatsprämie = 
            string praemie = aktuell.ToString(CultureInfo.InvariantCulture);
            Assert.AreEqual("302", praemie);
        }

        #endregion

        #region Testing 2

        [TestMethod]
        public void Praemienberechnung2()
        {
            //Arrange Der Versicherungsnehmer wählt die Franchise 300 und Versicherungsmodell keine
            string franchise = "1000";
            string vModell = "Telmed";

            // Act Die Monatsprämie wird berechnet
            double aktuell = Person.GetMonatsPraemie(franchise, vModell);

            // Assert Die erwartete Ergebnis ist: Monatsprämie = 
            string praemie = aktuell.ToString(CultureInfo.InvariantCulture);
            Assert.AreEqual("226.1", praemie);
        }

        #endregion

        #region Testing 3

        [TestMethod]
        public void Praemienberechnung3()
        {
            //Arrange Der Versicherungsnehmer wählt die Franchise 300 und Versicherungsmodell keine
            string franchise = "2500";
            string vModell = "Hmo";

            // Act Die Monatsprämie wird berechnet
            double aktuell = Person.GetMonatsPraemie(franchise, vModell);

            // Assert Die erwartete Ergebnis ist: Monatsprämie =
            string praemie = aktuell.ToString(CultureInfo.InvariantCulture);
            Assert.AreEqual("172.96", praemie);
        }

        #endregion
    }

}
