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

            browser = new Browser();

            browser.DodajSubscribera(subscriber1);
            browser.DodajSubscribera(subscriber2);
            browser.DodajSubscribera(subscriber3);
            browser.DodajSubscribera(subscriber4);

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
            subscriber4.OdaberiSerijeZaPretplatu(new List<Serija>() { s3 });
        }

        [TestMethod]
        public void NemaIzbacivanjaTest()
        {
            //Plati za svakog lika
            subscribers.ForEach(s => s.PlatiPretplatu(s.Password));
            browser.BrisanjeSubscribera();
            Assert.IsTrue(browser.Pretplatnici.Count == 4);
        }
    }
}
