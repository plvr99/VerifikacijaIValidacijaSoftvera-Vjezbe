using BrowserSerija;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Zadatak_1_Tests
{
    [TestClass]
    public class SerijaTests
    {
        public Serija serija;

        //Set up implementirao Kenan Selimovic
        [TestInitialize]
        public void SetUp()
        {
            serija = new Serija("Naziv", "Opis SAD SAD Opis Opis Opis Opis", Žanr.Američka);
        }

        //Test implementirao Kenan Selimovic
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Broj epizoda mora biti pozitivan cijeli broj")]
        public void Test1BrojEpizodaManjiOd0()
        {
            serija.DodajEpizode(false, -5);
        }

        //Test implementirao Muhamed Omerovic
        [TestMethod]
        public void Test1DodanaPrvaEpizodaPrveSezone()
        {
            Assert.IsTrue(serija.BrojSezona == 0);
            Assert.IsTrue(serija.BrojEpizoda.Count == 0);
            serija.DodajEpizode(false, 5);
            Assert.IsTrue(serija.BrojSezona == 1);
            Assert.IsTrue(serija.BrojEpizoda[0] == 5);
        }

        //Test implementirao Muhamed Omerovic
        [TestMethod]
        public void Test2DodanaEpizodaVecPostojeceSezone()
        {
            var brEp = serija.DodajEpizode(false, 5);
            Assert.IsTrue(serija.BrojSezona == 1);
            Assert.IsTrue(brEp == 5);

            brEp = serija.DodajEpizode(false, 10);
            Assert.IsTrue(brEp == 15);
            Assert.IsTrue(serija.BrojEpizoda[serija.BrojSezona - 1] == brEp);
        }

        //Test implementirao Muhamed Omerovic
        [TestMethod]
        public void Test3DodanaEpizodaNoveSezone()
        {
            var brEp = serija.DodajEpizode(false, 5);
            Assert.IsTrue(serija.BrojSezona == 1);
            Assert.IsTrue(brEp == 5);

            brEp = serija.DodajEpizode(true, 10);
            Assert.IsTrue(brEp == 15);
            Assert.IsTrue(serija.BrojEpizoda[serija.BrojSezona - 1] == 10);
        }
    }
}
