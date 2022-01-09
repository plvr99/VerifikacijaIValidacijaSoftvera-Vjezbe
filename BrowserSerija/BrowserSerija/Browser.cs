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

        public void RadSaSerijama(Serija serija, int opcija, double maxPopularnost)
        {
            Serija postojeća = null;
            foreach (var s in serije)
            {
                if (serija.Ime == s.Ime && serija.Opis != s.Opis)
                    continue;
                else if (serija.Ime == s.Ime)
                {
                    if (s.PopularnostSerije > maxPopularnost)
                        continue;
                    else if (serija.PopularnostSerije > maxPopularnost)
                        continue;
                    else if (s.PopularnostSerije == serija.PopularnostSerije)
                        postojeća = s;
                }
            }
            if (serija == null || serije.FindAll(s => s.Ime == serija.Ime) == null)
                throw new InvalidCastException("Nemoguće raditi sa serijom koja nije specificirana!");
            if (postojeća != null && serije.FindAll(s => s.Ime == serija.Ime) != null && opcija == 1)
                throw new ArgumentException("Nemoguće dodati seriju koja već postoji!");
            else if (postojeća == null && serije.FindAll(s => s.Ime == serija.Ime) == null && opcija > 1 && opcija < 4)
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

        public void NapraviRaspored(Raspored ovosedmičniRaspored)
        {
            if (rasporedi.Find(r => r.Pocetak == ovosedmičniRaspored.Pocetak || r.Kraj == ovosedmičniRaspored.Kraj) != null)
                throw new ArgumentException("Raspored za datu sedmicu je već definisan!");
            else if (Math.Abs((ovosedmičniRaspored.Kraj - ovosedmičniRaspored.Pocetak).TotalDays - 7) > 0.25)
                throw new ArgumentException("Raspored treba trajati 7 dana!");
            
            for (int i = 0; i < ovosedmičniRaspored.Serije.Count; i++)
            {
                if (!serije.Contains(ovosedmičniRaspored.Serije[i]))
                    throw new ArgumentException("Unijeli ste seriju koja nije registrovana!");
                else
                    continue;
            }

            rasporedi.Add(ovosedmičniRaspored);
        }
        public void NapraviRasporedRefactor(Raspored ovosedmičniRaspored)
        {
            if (rasporedi.Find(r => r.Pocetak == ovosedmičniRaspored.Pocetak || r.Kraj == ovosedmičniRaspored.Kraj) != null)
                throw new ArgumentException("Raspored za datu sedmicu je već definisan!");
            else if (Math.Abs((ovosedmičniRaspored.Kraj - ovosedmičniRaspored.Pocetak).TotalDays - 7) > 0.25)
                throw new ArgumentException("Raspored treba trajati 7 dana!");
            ProvjeraRasporedaRefactor(ovosedmičniRaspored);
            
        }

        private void ProvjeraRasporedaRefactor(Raspored ovosedmičniRaspored)
        {
            // pomocna metoda za NapraviRasporedRefactor
            for (int i = 0; i < ovosedmičniRaspored.Serije.Count; i++)
            {
                if (!serije.Contains(ovosedmičniRaspored.Serije[i]))
                    throw new ArgumentException("Unijeli ste seriju koja nije registrovana!");
            }
        }

        #endregion
    }
}
