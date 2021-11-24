using BrowserSerija;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;

namespace Zadatak_1_Tests
{
    [TestClass]
    public class SerijaTests
    {
        public Serija serija;

        #region Zadatak3 InitializeXML
        //Implementirao Adnan Palavra
        static IEnumerable<object[]> SerijeFailedXML
        {
            get
            {
                return UčitajPodatkeXMLFailed();
            }
        }

        static IEnumerable<object[]> SerijeValidXML
        {
            get
            {
                return UčitajPodatkeXMLValid();
            }
        }

        public static IEnumerable<object[]> UčitajPodatkeXMLFailed()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile1.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }
                yield return new object[] { elements[0], elements[1],int.Parse(elements[2]), elements[3]};
            }
        }

        public static IEnumerable<object[]> UčitajPodatkeXMLValid()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("SerijeValidXML.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }
                yield return new object[] { elements[0], elements[1], int.Parse(elements[2]), elements[3] };
            }
        }

        #endregion

        #region Zadatak1

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
        #endregion

        #region Zadatak3
        //Implementirao Adnan Palavra
        [TestMethod]
        [DynamicData("SerijeFailedXML")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestKonstruktoraSerijeXMLLos(string ime, string opis, int žanr, string glumci)
        {
            Žanr zanr = (Žanr)žanr;
            Serija s = new Serija(ime, opis, zanr);
        }
        //Test implementirao Muhamed Omerovic
        [TestMethod]
        [DynamicData("SerijeValidXML")]
        public void TestKonstruktoraSerijeXMLDobar(string ime, string opis, int žanr, string glumci)
        {
            Žanr zanr = (Žanr)žanr;
            Serija s = new Serija(ime, opis, zanr);
            StringAssert.Equals(s.Ime, ime);
            Assert.AreEqual(s.Opis, opis);
            Assert.IsTrue(s.Glumci.Count < 1);

            Glumac g1 = new Glumac("Will Smith", "SAD", DateTime.ParseExact("25/09/1968", "dd/MM/yyyy", null));
            s.DodajGlumca(g1);
            Assert.IsFalse(s.Glumci.Count < 1);
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSetteraGlumaca()
        {
            Serija s = new Serija("Ime Validne Serije", "Opis Serije koji ima dobar zanr SAD", Žanr.Američka);
            Glumac g1 = new Glumac("Will Smith", "SAD", DateTime.ParseExact("25/09/1968", "dd/MM/yyyy", null));
            s.DodajGlumca(g1);
            s.Glumci =null;
        }

        #endregion
    }
}
