using BrowserSerija;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Zadatak_1_Tests
{
    [TestClass]
    public class GlumacTests
    {
        public Glumac g1;
        public Glumac g2;
        public Browser browser;
        public Serija s;

        #region CSVInitialize Zadatak3
        //Implementirao Omerovic Muhamed
        static IEnumerable<object[]> GlumacFailedCSV
        {
            get
            {
                return UčitajPodatkeCSVGlumacFailed();
            }
        }

        static IEnumerable<object[]> GlumacValidCSV
        {
            get
            {
                return UčitajPodatkeCSVGlumacValid();
            }
        }

        public static IEnumerable<object[]> UčitajPodatkeCSVGlumacValid()
        {
            using (var reader = new StreamReader("GlumacValidCSV.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], DateTime.ParseExact(elements[2], "dd/MM/yyyy", null)};
                }
            }
        }

        public static IEnumerable<object[]> UčitajPodatkeCSVGlumacFailed()
        {
            using (var reader = new StreamReader("GlumacFailedCSV.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], DateTime.ParseExact(elements[2], "dd/MM/yyyy", null) };
                }
            }
        }

        #endregion

        #region Zadatak1

        //Set up napisao Adnan Palavra
        [TestInitialize]
        public void SetUp() {
            g1 = new Glumac("Will Smith", "SAD", DateTime.ParseExact("25/09/1968", "dd/MM/yyyy", null));
            g2 = new Glumac("Neki lažni glumac", "Neka lažna zemlja", DateTime.Now.AddDays(-1));
            s = new Serija("The Fresh Prince of Bel Air", "Serija iz SAD za sve generacije!", Žanr.Američka, new List<Glumac>() { g1, g2 });
            browser = new Browser();
            browser.RadSaSerijama(s, 1);
        }

        //Test Napisao Kenan Selimovic
        [TestMethod]
        public void Test1FaktorPopularnosti0_2AliUkupnaPopularnostIspod5()
        {
            var popularnost = g1.Popularnost;
            Assert.AreEqual(popularnost,0);
            g1.ZabilježiUčešćeUSeriji(8.1);
            Assert.AreEqual(g1.Popularnost, popularnost+0.5);
        }

        //Test Napisao Adnan Palavra
        [TestMethod]
        public void Test2FaktorPopularnosti0_2AliUkupnaPopularnostIspod5APopularnostSerijeIspod2()
        {
            var popularnost = g1.Popularnost;
            Assert.AreEqual(popularnost, 0);
            g1.ZabilježiUčešćeUSeriji(1.9);
            Assert.AreEqual(g1.Popularnost, 0);
        }

        //Test Napisao Kenan Selimovic
        [TestMethod]
        public void Test3FaktorPopularnosti0_2AliUkupnaPopularnostPreko5()
        {
            //Dovesti popularnost do 5
            while (g1.Popularnost < 5) g1.ZabilježiUčešćeUSeriji(8.1);

            var popularnost = g1.Popularnost;
            Assert.AreEqual(popularnost, 5);
            g1.ZabilježiUčešćeUSeriji(8.1);
            Assert.AreEqual(g1.Popularnost, popularnost*1.2);
        }

        //Test Napisao Adnan Palavra
        [TestMethod]
        public void Test4FaktorPopularnosti0_1AliUkupnaPopularnostPreko5()
        {
            //Dovesti popularnost do 5
            while (g1.Popularnost < 5) g1.ZabilježiUčešćeUSeriji(8.1);

            var popularnost = g1.Popularnost;
            Assert.AreEqual(popularnost, 5);
            g1.ZabilježiUčešćeUSeriji(6);
            Assert.AreEqual(g1.Popularnost, popularnost * 1.1);
        }

        //Test Napisao Kenan Selimovic
        [TestMethod]
        public void Test5PopularnostNeSmijePreciMaximum()
        {
            //Dovesti popularnost do 10
            while (g1.Popularnost < 10) g1.ZabilježiUčešćeUSeriji(8.1);

            var popularnost = g1.Popularnost;
            Assert.AreEqual(popularnost, 10);
            g1.ZabilježiUčešćeUSeriji(6);
            Assert.AreEqual(g1.Popularnost, 10);
        }

        #endregion

        #region Zadatak3
        //Test implementirao Muhamed Omerovic
        [TestMethod]
        [DynamicData("GlumacFailedCSV")]
        [ExpectedException(typeof(FormatException))]
        public void TestKonstruktoraGlumcaLosCSV(string ime, string nacionalnost, DateTime rođenje)
        {
            //Test implementirao Adnan Palavra
            Glumac g = new Glumac(ime, nacionalnost, rođenje);
        }


        //Test implementirao Adnan Palavra
        [TestMethod]
        [DynamicData("GlumacValidCSV")]
        public void TestKonstruktoraGlumcaDobarCSV(string ime, string nacionalnost, DateTime rođenje)
        {
            //Test implementirao Muhamed Omerovic
            Glumac g = new Glumac(ime, nacionalnost, rođenje);
            StringAssert.Equals(g.Ime, ime);
            Assert.AreEqual(g.Nacionalnost, nacionalnost);
            Assert.IsTrue(g.DatumRođenja.Equals(rođenje));
        }

        #endregion

    }
}
