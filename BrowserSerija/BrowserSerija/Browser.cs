using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserSerija
{
    public class Browser
    {
        #region Atributi

        List<Serija> serije;
        List<Raspored> rasporedi;
        List<Subscriber> pretplatnici;
        static int maksimalniZabilježeniBrojGledalaca;

        #endregion

        #region Properties

        public List<Serija> Serije { get => serije; }
        public List<Raspored> Rasporedi { get => rasporedi; }
        public List<Subscriber> Pretplatnici { get => pretplatnici; set => pretplatnici = value; }
        public static int MaksimalniZabilježeniBrojGledalaca { get => maksimalniZabilježeniBrojGledalaca; }

        #endregion
        

        #region Konstruktor

        public Browser()
        {
            serije = new List<Serija>();
            rasporedi = new List<Raspored>();
            pretplatnici = new List<Subscriber>();
            maksimalniZabilježeniBrojGledalaca = 1;
        }

        #endregion

        #region Metode

        public void RadSaSerijama(Serija serija, int opcija)
        {
            if (serija == null)
                throw new InvalidCastException("Nemoguće raditi sa serijom koja nije specificirana!");
            Serija postojeća = serije.Find(s => s.Ime == serija.Ime);
            if (postojeća != null && opcija == 1)
                throw new ArgumentException("Nemoguće dodati seriju koja već postoji!");
            else if (postojeća == null && opcija > 1 && opcija < 4)
                throw new ArgumentException("Nemoguće izvršiti izmjenu/brisanje serije koja ne postoji!");

            if (opcija == 1)
                serije.Add(serija);
            else if (opcija == 2)
            {
                serije.Remove(postojeća);
                serije.Add(serija);
            }
            else if (opcija == 3)
            {
                serije.Remove(postojeća);
            }
            else
                throw new InvalidCastException("Unijeli ste nepostojeću opciju!");
        }

        public void DodajGlumca(Glumac glumac, string imeSerije)
        {
            Serija postojeća = serije.Find(s => s.Ime == imeSerije);
            if (postojeća == null)
                throw new InvalidOperationException("Serija koju ste specificirali ne postoji!");

            postojeća.DodajGlumca(glumac);
            glumac.ZabilježiUčešćeUSeriji(postojeća.PopularnostSerije);
        }

        public void DodajGledanostEpizode(Serija serija, bool korekcijaZaProšluEpizodu, int brojGledalaca)
        {
            if (!serije.Contains(serija))
                throw new ArgumentException("Serija nije registrovana!");

            if (korekcijaZaProšluEpizodu && serija.TrenutniBrojGledalaca + brojGledalaca > maksimalniZabilježeniBrojGledalaca)
                maksimalniZabilježeniBrojGledalaca = serija.TrenutniBrojGledalaca + brojGledalaca;
            else if (!korekcijaZaProšluEpizodu && brojGledalaca > maksimalniZabilježeniBrojGledalaca)
                maksimalniZabilježeniBrojGledalaca = brojGledalaca;

            serija.ZabilježiGledanost(korekcijaZaProšluEpizodu, brojGledalaca);
        }

        public void DodajSubscribera(Subscriber s)
        {
            if (!pretplatnici.Contains(s))
                pretplatnici.Add(s);
        }

        /// <summary>
        /// Metoda koja briše subscribere koji ne plaćaju redovno svoju članarinu.
        /// Prvo je potrebno pronaći sve pretplatnike koji nisu platili pretplatu.
        /// Subscriber će biti obrisan iz liste pretplatnika u sljedećim slučajevima:
        /// - ako je rok za uplatu pretplate istekao prije više od mjesec dana;
        /// - ukoliko je rok za uplatu pretplate istekao prije više od dvije sedmice,
        /// a cijena pretplate je veća od 50 KM;
        /// - ukoliko je rok za uplatu pretplate istekao prije više od sedmicu dana,
        /// a cijena pretplate je veća od 100 KM.
        /// Ukoliko u listi pretplatnika nema nijedan pretplatnik, nije potrebno bacati
        /// nikakve izuzetke.
        /// </summary>
        public void BrisanjeSubscribera()
        {
            //Funkciju implementirao Kenan Selimovic
            var pretplatniciCopy = new List<Subscriber>();

            pretplatnici.ForEach(p =>
            {
                if (p.PretplataPlaćena == false) {

                    DateTime trenutno = DateTime.Now;
                    if ((trenutno.Month - p.RokUplate.Month) + 12 * (p.RokUplate.Year - trenutno.Year) >= 1)
                    {
                        pretplatniciCopy.Add(p);
                    }
                    else if (((trenutno - p.RokUplate).Days) > 14 && p.UkupnaCijenaPretplate > 50)
                    {
                        pretplatniciCopy.Add(p);
                    }
                    else if ((trenutno - p.RokUplate).Days > 7 && p.UkupnaCijenaPretplate > 100)
                    {
                        pretplatniciCopy.Add(p);
                    }
                }
            });
            foreach(var p in pretplatniciCopy) pretplatnici.Remove(p);
        }

        public double PlaćanjePretplate(Subscriber subscriber, bool promjenaSerija = false, List<Serija> noveSerije = null)
        {
            if (!pretplatnici.Contains(subscriber))
                throw new InvalidOperationException("Subscriber kojeg ste poslali nije registrovan!");

            subscriber.PlatiPretplatu(subscriber.Password);

            if (promjenaSerija)
            {
                double novaCijena = subscriber.OdaberiSerijeZaPretplatu(noveSerije);
                return novaCijena;
            }
            else
                return subscriber.UkupnaCijenaPretplate;
        }

        public void PrekontrolišiSerije(IBazaFilmova baza)
        {
            foreach (Serija s in serije)
            {
                List<Glumac> glumciZaBrisanje = new List<Glumac>();
                List<string> sviGlumciSerije = baza.GlumciSerije(s.Ime);
                foreach (Glumac g in s.Glumci)
                {
                    if (sviGlumciSerije.Contains(g.Ime))
                        glumciZaBrisanje.Add(g);
                }
                s.Glumci.RemoveAll(gl => glumciZaBrisanje.Contains(gl));
            }
        }

        public void NapraviRaspored(Raspored ovosedmičniRaspored)
        {
            if (rasporedi.Find(r => r.Pocetak == ovosedmičniRaspored.Pocetak || r.Kraj == ovosedmičniRaspored.Kraj) != null)
                throw new ArgumentException("Raspored za datu sedmicu je već definisan!");
            else if (Math.Abs((ovosedmičniRaspored.Kraj - ovosedmičniRaspored.Pocetak).TotalDays - 7) > 0.25)
                throw new ArgumentException("Raspored treba trajati 7 dana!");
            
            foreach (Serija s in ovosedmičniRaspored.Serije)
            {
                if (!serije.Contains(s))
                    throw new ArgumentException("Unijeli ste seriju koja nije registrovana!");
            }

            foreach (DateTime datum in ovosedmičniRaspored.VremenaPrikazivanja)
            {
                if (datum < ovosedmičniRaspored.Pocetak || datum > ovosedmičniRaspored.Kraj)
                    throw new ArgumentException("Unijeli ste pogrešan datum u raspored!");
            }

            rasporedi.Add(ovosedmičniRaspored);
        }

        public void AutomatskoDodavanjeRasporeda(bool samoPopularneSerije = false)
        {
            List<Serija> serije = null;
            if (Serije.Count < 1) throw new ArgumentNullException("Nema Serija za dodati");
            if (samoPopularneSerije)
            {
                serije = new();
                foreach (var s in Serije) 
                {
                    if (s.PopularnostSerije >= 5) serije.Add(s);
                }
                if (serije.Count < 1) throw new InvalidOperationException("Nemoguce dodavanje serija");
            }
            else
            {
                serije = Serije;
            }


            DateTime datumPocetka = new();
            DateTime datumKraja = new();
            List<DateTime> prikazivanja = new();

            if (Rasporedi.Count < 1)
            {
                //Napravi prvi raspored od danasnjeg datuma
                datumPocetka = DateTime.Now;
                datumKraja = datumPocetka.AddDays(7);
            }
            else 
            {
                //Postoji raspored, uzmi zadnji i dodaj jedan dan
                datumPocetka = Rasporedi.Last().Kraj.AddDays(1);
                datumKraja = datumPocetka.AddDays(7);
            }

            //Kreiranje rasporeda
            int brSerijaPoDanu = (int)Math.Ceiling((0.0 + serije.Count) / 7);

            int brojacSerije = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < brSerijaPoDanu; j++)
                {
                    if (brojacSerije == serije.Count - 1) break;
                    else
                    {
                        DateTime vrijeme = datumPocetka.AddDays(i).AddMinutes(j*30);
                        prikazivanja.Add(vrijeme);
                    }
                    brojacSerije++;
                }
            }

            Raspored raspored = new Raspored(datumPocetka,datumKraja,serije,prikazivanja);
            NapraviRaspored(raspored);
        }

        #endregion
    }
}
