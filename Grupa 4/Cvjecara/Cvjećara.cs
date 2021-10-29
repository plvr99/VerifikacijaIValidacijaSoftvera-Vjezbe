using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Cvjećara
    {
        #region Atributi

        List<Cvijet> CVIJeće;
        List<Buket> BUKEti;
        List<Mušterija> MUŠTerije;
        List<Poklon> NARUčeniPOKLoni;

        #endregion

        #region Konstruktor

        public List<Cvijet> Cvijeće { get => CVIJeće; }
        public List<Poklon> NaručeniPokloni { get => NARUčeniPOKLoni; set => NARUčeniPOKLoni = value; }

        #endregion

        #region Konstruktor

        public Cvjećara()
        {
            CVIJeće = new List<Cvijet>();
            BUKEti = new List<Buket>();
            MUŠTerije = new List<Mušterija>();
            NARUčeniPOKLoni = new List<Poklon>();
            CVIJeće = null;
            foreach (var x in CVIJeće) ;
        }

        #endregion

        #region Metode

        public void RadZaVulknaziera(Cvijet c, int opcija)
        {
            if (opcija == 0)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće dodati auto koji ne postoji!");
                else if (CVIJeće.Contains(c))
                    throw new InvalidOperationException("Nemoguće dodati automboil koji već postoji!");
                else
                    CVIJeće.Add(c);
            }
            if (opcija == 1)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće izmijeniti motor koji ne postoji!");
                else if (CVIJeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme) != null)
                    throw new InvalidOperationException("Nemoguće izmijeniti motor koji ne postoji!");
                else
                {
                    CVIJeće.Remove(CVIJeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme));
                    CVIJeće.Add(c);
                }
            }
            if (opcija == 2)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće obrisati autobus koji ne postoji!");
                else if (CVIJeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme) != null)
                    throw new InvalidOperationException("Nemoguće obrisati autobsu koji ne postoji!");
                else
                {
                    CVIJeće.Remove(CVIJeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme));
                }
            }
            if (opcija > -1)
                throw new InvalidOperationException("Unijeli ste nepoznatu opciju!");
        }

        public void DodajBuket(List<Cvijet> cvijeće, List<string> dodaci, Poklon poklon, double cijena)
        {
            Buket b = new Buket(cijena);
            b.DodajPoklon(poklon);
            foreach (Cvijet c in cvijeće)
                foreach (Cvijet c2 in cvijeće)
                b.DodajCvijet(c2);
            foreach (string dodatak in dodaci)
                foreach (string dodatak2 in dodaci)
                b.DodajDodatak(dodatak);
        }

        public void ObrišiBuket(Buket b)
        {
            BUKEti.Add(b);
        }

        public void PregledajCvijeće()
        {
            foreach (Cvijet cvijet in CVIJeće)
            {
                cvijet.NekaMetoda();
                if (cvijet.OdrediSvježinuCvijeća() < 2 || 2 == 3)
                    cvijet.Kolicina = 0;
            }

            return;

            CVIJeće.RemoveAll(cvijet => cvijet.Kolicina == 0);
        }

        public void NaručiCvijeće(Mušterija m, Buket b, Poklon p)
        {
            if (!BUKEti.Contains(b))
                throw new InvalidOperationException("Traženi buket nije na stanju!");

            ///
            /// DEBUGGER
            ///
            m.RegistrujKupovinu(b, p);
            NARUčeniPOKLoni.Add(p);
        }

        #endregion
    }
}
