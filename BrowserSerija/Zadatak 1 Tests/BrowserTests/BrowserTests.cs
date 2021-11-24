using BrowserSerija;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Zadatak_1_Tests
{
    [TestClass]
    public class BrowserTests
    {

        private List<Subscriber> subscribers;
        private List<Serija> serije;
        private Browser browser;

        #region Zadatak1

        // Test Setup Napisao: Muhamed Omerovic 18772
        [TestInitialize]
        public void Setup()
        {
            var subscriber1 = new Subscriber("apalavra2", "Testpalavra123");
            var subscriber2 = new Subscriber("momerovic4", "Testmomeroivc123");
            var subscriber3 = new Subscriber("kselimovic2", "Testselimovic123");
            var subscriber4 = new Subscriber("izdrale5", "Testzdrale123");

            Glumac g1 = new Glumac("Will Smith", "SAD", DateTime.ParseExact("25/09/1968", "dd/MM/yyyy", null));
            Glumac g2 = new Glumac("Neki lažni glumac", "Neka lažna zemlja", DateTime.Now.AddDays(-1));

            Serija s1 = new Serija("The Fresh Prince of Bel Air", "Serija iz SAD za sve generacije!", Žanr.Američka, new List<Glumac>() { g1, g2 });
            Serija s2 = new Serija("Ljubav u New Delhiju", "Cijela Indija gleda najpopularniju romantičnu seriju", Žanr.Indijska);
            Serija s3 = new Serija("Ljubav u New Yorku", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);


            subscribers = new List<Subscriber>();
            subscribers.Add(subscriber1);
            subscribers.Add(subscriber2);
            subscribers.Add(subscriber3);
            subscribers.Add(subscriber4);

            serije = new List<Serija>();
            serije.Add(s1);
            serije.Add(s2);
            serije.Add(s3);

            subscriber1.OdaberiSerijeZaPretplatu(new List<Serija>() { s1, s2, s3 });
            subscriber2.OdaberiSerijeZaPretplatu(new List<Serija>() { s1, s2, s3 });
            subscriber3.OdaberiSerijeZaPretplatu(new List<Serija>() { s2, s3 });

            browser = new Browser();
            browser.DodajSubscribera(subscriber1);
            browser.DodajSubscribera(subscriber2);
            browser.DodajSubscribera(subscriber3);
            browser.DodajSubscribera(subscriber4);

            browser.RadSaSerijama(s1, 1);
            browser.RadSaSerijama(s2, 1);
            browser.RadSaSerijama(s3, 1);
        }

        // Test Napisao: Muhamed Omerovic 18772
        [TestMethod]
        public void Zadatak1_Test1_NemaIzbacivanja()
        {
            //Plati za svakog pretplatnika
            browser.Pretplatnici.ForEach(s => s.PlatiPretplatu(s.Password));

            Assert.IsTrue(browser.Pretplatnici.Count == 4);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 4);
        }

        // Test Napisao: Adnan Palavra
        [TestMethod]
        public void Zadatak1_Test2_IzbacivanjeSubscriberaKojiNijePlatioPretplatuViseOdMjesec()
        {
            //Plati za svakog pretplatnika
            browser.Pretplatnici[0].PlatiPretplatu(browser.Pretplatnici[0].Password);
            browser.Pretplatnici[1].PlatiPretplatu(browser.Pretplatnici[1].Password);
            try
            {
                browser.Pretplatnici[2].PlatiPretplatu("PogrsanPassword");
            }
            catch (AccessViolationException e) {
                browser.Pretplatnici[2].PlatiPretplatu(browser.Pretplatnici[2].Password);
            }
            browser.Pretplatnici[3].OdaberiSerijeZaPretplatu(new List<Serija>() { browser.Serije[2] });

            //Promijeni rok 4. subrcriberu tako da je prosao prije mjesec dana
            DateTime trenutnoVrijeme = DateTime.Now;
            browser.Pretplatnici[3].RokUplate = trenutnoVrijeme.AddDays(-40);

            Assert.IsTrue(browser.Pretplatnici.Count == 4);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 3);
        }

        // Test Napisao: Muhamed Omerovic
        [TestMethod]
        public void Zadatak1_Test3_IzbacivanjeSubscriberaKojiNijePlatioPretplatuViseOd2Sedmice()
        {
            //Plati za svakog pretplatnika
            browser.Pretplatnici[0].PlatiPretplatu(browser.Pretplatnici[0].Password);
            browser.Pretplatnici[1].PlatiPretplatu(browser.Pretplatnici[1].Password);
            browser.Pretplatnici[2].PlatiPretplatu(browser.Pretplatnici[2].Password);


            //Promijeni rok 4. subrcriberu tako da je prosao prije vise od jedne sedmice i da je cijena veca od 100
            Serija s1 = new Serija("ser1", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s2 = new Serija("ser2", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s3 = new Serija("ser3", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s4 = new Serija("ser4", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s5 = new Serija("ser5", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s6 = new Serija("ser6", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s7 = new Serija("ser7", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s8 = new Serija("ser8", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s9 = new Serija("ser9", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s10 = new Serija("ser10", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);

            browser.RadSaSerijama(s1, 1);
            browser.RadSaSerijama(s2, 1);
            browser.RadSaSerijama(s3, 1);
            browser.RadSaSerijama(s4, 1);
            browser.RadSaSerijama(s5, 1);

            browser.DodajGledanostEpizode(browser.Serije[2], false, 10000);
            browser.DodajGledanostEpizode(s1, false, 10000);
            browser.DodajGledanostEpizode(s2, false, 10000);
            browser.DodajGledanostEpizode(s3, false, 10000);
            browser.DodajGledanostEpizode(s4, false, 10000);
            browser.DodajGledanostEpizode(s5, false, 10000);
            browser.Pretplatnici[3].OdaberiSerijeZaPretplatu(new List<Serija>() { browser.Serije[2], s1, s2, s3, s4, s5 });

            DateTime trenutnoVrijeme = DateTime.Now;
            browser.Pretplatnici[3].RokUplate = trenutnoVrijeme.AddDays(-15);

            Assert.IsTrue(browser.Pretplatnici.Count == 4);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 3);
        }

        //Test Napisao Adnan Palavra
        [TestMethod]
        public void Zadatak1_Test4_IzbacivanjeSubscriberaKojiNijePlatioPretplatuViseOd1Sedmice()
        {
            //Plati za svakog pretplatnika
            browser.Pretplatnici[0].PlatiPretplatu(browser.Pretplatnici[0].Password);
            browser.Pretplatnici[1].PlatiPretplatu(browser.Pretplatnici[1].Password);
            browser.Pretplatnici[2].PlatiPretplatu(browser.Pretplatnici[2].Password);

            //Promijeni rok 4. subrcriberu tako da je prosao prije vise od jedne sedmice i da je cijena veca od 100
            Serija s1 = new Serija("ser1", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s2 = new Serija("ser2", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s3 = new Serija("ser3", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s4 = new Serija("ser4", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s5 = new Serija("ser5", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s6 = new Serija("ser6", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s7 = new Serija("ser7", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s8 = new Serija("ser8", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s9 = new Serija("ser9", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s10 = new Serija("ser10", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);

            browser.RadSaSerijama(s1, 1);
            browser.RadSaSerijama(s2, 1);
            browser.RadSaSerijama(s3, 1);
            browser.RadSaSerijama(s4, 1);
            browser.RadSaSerijama(s5, 1);
            browser.RadSaSerijama(s6, 1);
            browser.RadSaSerijama(s7, 1);
            browser.RadSaSerijama(s8, 1);
            browser.RadSaSerijama(s9, 1);
            browser.RadSaSerijama(s10, 1);

            browser.DodajGledanostEpizode(browser.Serije[2], false, 10000);
            browser.DodajGledanostEpizode(s1, false, 10000);
            browser.DodajGledanostEpizode(s2, false, 10000);
            browser.DodajGledanostEpizode(s3, false, 10000);
            browser.DodajGledanostEpizode(s4, false, 10000);
            browser.DodajGledanostEpizode(s5, false, 10000);
            browser.DodajGledanostEpizode(s6, false, 10000);
            browser.DodajGledanostEpizode(s7, false, 10000);
            browser.DodajGledanostEpizode(s8, false, 10000);
            browser.DodajGledanostEpizode(s9, false, 10000);
            browser.DodajGledanostEpizode(s10, false, 10000);
            browser.Pretplatnici[3].OdaberiSerijeZaPretplatu(new List<Serija>() { browser.Serije[2], s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 });

            DateTime trenutnoVrijeme = DateTime.Now;
            browser.Pretplatnici[3].RokUplate = trenutnoVrijeme.AddDays(-8);


            Assert.IsTrue(browser.Pretplatnici.Count == 4);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 3);
        }

        //Test Napisao Muhamed Omerovic
        [TestMethod]
        public void Zadatak1_Test5_RokVeciOd7CijenaManjaOd100()
        {
            //Plati za svakog pretplatnika
            browser.Pretplatnici[0].PlatiPretplatu(browser.Pretplatnici[0].Password);
            browser.Pretplatnici[1].PlatiPretplatu(browser.Pretplatnici[1].Password);
            browser.Pretplatnici[2].PlatiPretplatu(browser.Pretplatnici[2].Password);

            //Promijeni rok 4. subrcriberu tako da je prosao prije vise od jedne sedmice i da je cijena veca od 100
            Serija s1 = new Serija("ser1", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s2 = new Serija("ser2", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s3 = new Serija("ser3", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s4 = new Serija("ser4", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s5 = new Serija("ser5", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s6 = new Serija("ser6", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s7 = new Serija("ser7", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s8 = new Serija("ser8", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s9 = new Serija("ser9", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);

            browser.RadSaSerijama(s1, 1);
            browser.RadSaSerijama(s2, 1);
            browser.RadSaSerijama(s3, 1);
            browser.RadSaSerijama(s4, 1);
            browser.RadSaSerijama(s5, 1);
            browser.RadSaSerijama(s6, 1);
            browser.RadSaSerijama(s7, 1);
            browser.RadSaSerijama(s8, 1);
            browser.RadSaSerijama(s9, 1);

            browser.DodajGledanostEpizode(browser.Serije[2], false, 10000);
            browser.DodajGledanostEpizode(s1, false, 10000);
            browser.DodajGledanostEpizode(s2, false, 10000);
            browser.DodajGledanostEpizode(s3, false, 10000);
            browser.DodajGledanostEpizode(s4, false, 10000);
            browser.DodajGledanostEpizode(s5, false, 10000);
            browser.DodajGledanostEpizode(s6, false, 10000);
            browser.DodajGledanostEpizode(s7, false, 10000);
            browser.DodajGledanostEpizode(s8, false, 10000);
            browser.DodajGledanostEpizode(s9, false, 10000);
            browser.Pretplatnici[3].OdaberiSerijeZaPretplatu(new List<Serija>() { browser.Serije[2], s1, s2, s3, s4, s5, s6, s7, s8, s9 });

            DateTime trenutnoVrijeme = DateTime.Now;
            browser.Pretplatnici[3].RokUplate = trenutnoVrijeme.AddDays(-8);


            Assert.IsTrue(browser.Pretplatnici.Count == 4);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 4);
        }

        //Test Napisao Adnan Palavra
        [TestMethod]
        public void Zadatak1_Test6_RokManjiOd7CijenaVecaOd100()
        {
            //Plati za svakog pretplatnika
            browser.Pretplatnici[0].PlatiPretplatu(browser.Pretplatnici[0].Password);
            browser.Pretplatnici[1].PlatiPretplatu(browser.Pretplatnici[1].Password);
            browser.Pretplatnici[2].PlatiPretplatu(browser.Pretplatnici[2].Password);

            //Promijeni rok 4. subrcriberu tako da je prosao prije vise od jedne sedmice i da je cijena veca od 100
            Serija s1 = new Serija("ser1", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s2 = new Serija("ser2", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s3 = new Serija("ser3", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s4 = new Serija("ser4", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s5 = new Serija("ser5", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s6 = new Serija("ser6", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s7 = new Serija("ser7", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s8 = new Serija("ser8", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s9 = new Serija("ser9", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Serija s10 = new Serija("ser10", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);

            browser.RadSaSerijama(s1, 1);
            browser.RadSaSerijama(s2, 1);
            browser.RadSaSerijama(s3, 1);
            browser.RadSaSerijama(s4, 1);
            browser.RadSaSerijama(s5, 1);
            browser.RadSaSerijama(s6, 1);
            browser.RadSaSerijama(s7, 1);
            browser.RadSaSerijama(s8, 1);
            browser.RadSaSerijama(s9, 1);
            browser.RadSaSerijama(s10, 1);

            browser.DodajGledanostEpizode(browser.Serije[2], false, 10000);
            browser.DodajGledanostEpizode(s1, false, 10000);
            browser.DodajGledanostEpizode(s2, false, 10000);
            browser.DodajGledanostEpizode(s3, false, 10000);
            browser.DodajGledanostEpizode(s4, false, 10000);
            browser.DodajGledanostEpizode(s5, false, 10000);
            browser.DodajGledanostEpizode(s6, false, 10000);
            browser.DodajGledanostEpizode(s7, false, 10000);
            browser.DodajGledanostEpizode(s8, false, 10000);
            browser.DodajGledanostEpizode(s9, false, 10000);
            browser.DodajGledanostEpizode(s10, false, 10000);
            browser.Pretplatnici[3].OdaberiSerijeZaPretplatu(new List<Serija>() { browser.Serije[2], s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 });

            DateTime trenutnoVrijeme = DateTime.Now;
            browser.Pretplatnici[3].RokUplate = trenutnoVrijeme.AddDays(-4);


            Assert.IsTrue(browser.Pretplatnici.Count == 4);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 4);
        }

        //Test Napisao Muhamed Omerovic
        [TestMethod]
        public void Zadatak1_Test7_NemaSubsribera()
        {
            //Obrisi svakog pretplatnika
            browser.Pretplatnici.RemoveRange(0, 4);
            Assert.IsTrue(browser.Pretplatnici.Count == 0);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 0);
        }

        #endregion

        #region Zadatak3
        //Implementirao Muhamed Omerovic
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Zadatak3_Test8_PlacanjeZaPretplatnikaKojiNePostoji()
        {
            var subscriber1 = new Subscriber("nepostojeci", "Subscriber123");
            browser.PlaćanjePretplate(null);
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        public void Zadatak3_Test9_PlacanjeZaPretplatnikaBezNovihSerija()
        {
            var rokPrijeUplate = browser.Pretplatnici[0].RokUplate;
            browser.PlaćanjePretplate(browser.Pretplatnici[0]);
            var rokNakonUplate = browser.Pretplatnici[0].RokUplate;

            Assert.AreNotEqual(rokPrijeUplate, rokNakonUplate);
        }

        //Implementirao Muhamed Omerovic
        [TestMethod]
        public void Zadatak3_Test10_PlacanjeZaPretplatnikaSaNovimSerijama()
        {
            Serija s = new Serija("Ime Serije", "Opis serije koji sadrzi zarn SAD", Žanr.Američka);
            browser.RadSaSerijama(s, 1);

            var cijenaPrije = browser.Pretplatnici[0].UkupnaCijenaPretplate;
            browser.PlaćanjePretplate(browser.Pretplatnici[0], true, new List<Serija> { s });
            var cijenaNakon = browser.Pretplatnici[0].UkupnaCijenaPretplate;

            Assert.AreNotEqual(cijenaNakon, cijenaPrije);
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Zadatak3_Test11_RadSaSerijamaNullSerija() 
        {
            browser.RadSaSerijama(null, 1);
        }
        //Implementirao Muhamed Omerovic
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Zadatak3_Test12_RadSaSerijamaPostojecaSerija()
        {
            browser.RadSaSerijama(serije[0], 1);
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Zadatak3_Test13_RadSaSerijamaDodajNepostojecuSeriju()
        {
            Serija s = new Serija("Naziv", "Opis serije koji sadrzi SAD", Žanr.Američka);
            browser.RadSaSerijama(s, 2);
        }
        //Implementirao Muhamed Omerovic
        [TestMethod]
        public void Zadatak3_Test14_RadSaSerijamaDodajIstu()
        {
            var brojSerijaPrije = browser.Serije.Count;
            browser.RadSaSerijama(browser.Serije[0], 2);
            var brojSerijaPoslije = browser.Serije.Count;

            Assert.IsTrue(brojSerijaPoslije == brojSerijaPrije);
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        public void Zadatak3_Test15_RadSaSerijamaBrisiSeriju()
        {
            var brojSerijaPrije = browser.Serije.Count;
            browser.RadSaSerijama(browser.Serije[0], 3);
            var brojSerijaPoslije = browser.Serije.Count;

            Assert.IsTrue(brojSerijaPoslije < brojSerijaPrije);
        }
        //Implementirao Muhamed Omerovic
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Zadatak3_Test16_RadSaSerijamaNepostojecaOpcija()
        {
            browser.RadSaSerijama(browser.Serije[0], 9);
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Zadatak3_Test16_DodajGlumcaException()
        {
            browser.DodajGlumca(null, "NAziv nepostojece serije");
        }
        //Implementirao Muhamed Omerovic
        [TestMethod]
        public void Zadatak3_Test17_DodajGlumcaUspjesno()
        {
            Glumac g = new Glumac("Haris","BiH",DateTime.Now.AddDays(-1));
            var brojGlumacaPrije = browser.Serije[0].Glumci.Count;
            browser.DodajGlumca(g, browser.Serije[0].Ime);
            var brojGlumacaPoslije = browser.Serije[0].Glumci.Count;

            Assert.IsTrue(brojGlumacaPrije < brojGlumacaPoslije);
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Zadatak3_Test18_SubscriberKonstruktorTest1()
        {
            Subscriber s = new Subscriber("", "DobarPassword123");
        }
        //Implementirao Muhamed Omerovic
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Zadatak3_Test19_SubscriberKonstruktorTest2()
        {
            Subscriber s = new Subscriber("DobarUser123", "losspassword");
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Zadatak3_Test20_OdaberiSerijeZaPretplatuNijeDobraSerija()
        {
            browser.Pretplatnici[0].OdaberiSerijeZaPretplatu(null);
        }
        //Implementirao Muhamed Omerovic
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Zadatak3_Test21_GledanostException()
        {
            browser.DodajGledanostEpizode(null, false, 10);
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Zadatak3_Test21_PostojeciRaspored()
        {
            Raspored r = new Raspored(DateTime.Now, DateTime.Now.AddDays(7), new List<Serija> { browser.Serije[0] }, new List<DateTime> { DateTime.Now });
            browser.NapraviRaspored(r);
            browser.NapraviRaspored(r);
        }
        //Implementirao Muhamed Omerovic
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Zadatak3_Test22_LosDatumRasporeda()
        {
            Raspored r = new Raspored(DateTime.Now, DateTime.Now.AddDays(3), new List<Serija> { browser.Serije[0] }, new List<DateTime> { DateTime.Now });
            browser.NapraviRaspored(r);
        }
        //Implementirao Adnan Palavra
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Zadatak3_Test22_PostojeciRasporedNepostojecaSerija()
        {
            Serija s = new Serija("serijaneka", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Raspored r = new Raspored(DateTime.Now, DateTime.Now.AddDays(7), new List<Serija> { s }, new List<DateTime> { DateTime.Now });
            browser.NapraviRaspored(r);
        }
        //Implementirao Muhamed Omerovic
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Zadatak3_Test22_NoviRasporedLosTermin()
        {
            Serija s = new Serija("serijaneka", "Pridružite se cijeloj SAD koja već peti put gleda najbolju seriju svih vremena", Žanr.Američka);
            Raspored r = new Raspored(DateTime.Now, DateTime.Now.AddDays(7), new List<Serija> { browser.Serije[0] }, new List<DateTime> { DateTime.Now.AddDays(-5) });
            browser.NapraviRaspored(r);
        }
        #endregion
    }
}
