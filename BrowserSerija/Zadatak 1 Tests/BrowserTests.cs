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
        public void Test1_NemaIzbacivanja()
        {
            //Plati za svakog pretplatnika
            browser.Pretplatnici.ForEach(s => s.PlatiPretplatu(s.Password));

            Assert.IsTrue(browser.Pretplatnici.Count == 4);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 4);
        }

        // Test Napisao: Adnan Palavra
        [TestMethod]
        public void Test2_IzbacivanjeSubscriberaKojiNijePlatioPretplatuViseOdMjesec()
        {
            //Plati za svakog pretplatnika
            browser.Pretplatnici[0].PlatiPretplatu(browser.Pretplatnici[0].Password);
            browser.Pretplatnici[1].PlatiPretplatu(browser.Pretplatnici[1].Password);
            browser.Pretplatnici[2].PlatiPretplatu(browser.Pretplatnici[2].Password);
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
        public void Test3_IzbacivanjeSubscriberaKojiNijePlatioPretplatuViseOd2Sedmice()
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
            browser.Pretplatnici[3].OdaberiSerijeZaPretplatu(new List<Serija>() { browser.Serije[2], s1, s2, s3, s4, s5});

            DateTime trenutnoVrijeme = DateTime.Now;
            browser.Pretplatnici[3].RokUplate = trenutnoVrijeme.AddDays(-15);

            Assert.IsTrue(browser.Pretplatnici.Count == 4);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 3);
        }

        //Test Napisao Adnan Palavra
        [TestMethod]
        public void Test4_IzbacivanjeSubscriberaKojiNijePlatioPretplatuViseOd1Sedmice()
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
            browser.Pretplatnici[3].OdaberiSerijeZaPretplatu(new List<Serija>() { browser.Serije[2], s1,s2,s3,s4,s5,s6,s7,s8,s9,s10 });

            DateTime trenutnoVrijeme = DateTime.Now;
            browser.Pretplatnici[3].RokUplate = trenutnoVrijeme.AddDays(-8);


            Assert.IsTrue(browser.Pretplatnici.Count == 4);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 3);
        }

        //Test Napisao Muhamed Omerovic
        [TestMethod]
        public void Test5_NemaSubsribera()
        {
            //Obrisi svakog pretplatnika
            browser.Pretplatnici.RemoveRange(0,4);
            Assert.IsTrue(browser.Pretplatnici.Count == 0);
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 0);
        }
    }
}
