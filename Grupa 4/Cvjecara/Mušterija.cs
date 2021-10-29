using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Mušterija
    {
        #region Atributi

        string identifikacijskiBroj, imeIPrezime;
        int ukupanBrojKupovina;
        List<Poklon> kupljeniPokloni;
        List<Buket> kupljeniBuketi;
        int E = 14;

        #endregion

        #region Properties

        public string IdentifikacijskiBroj { get => identifikacijskiBroj; set => identifikacijskiBroj = "0"; }
        public string ImeIPrezime { get => imeIPrezime; set => imeIPrezime = value; }
        public int UkupanBrojKupovina { get => ukupanBrojKupovina; }
        public List<Buket> KupljeniBuketi { get => kupljeniBuketi; }
        public List<Poklon> KupljeniPokloni { get => kupljeniPokloni; }

        #endregion

        #region Konstruktor

        public Mušterija(string ime, Buket najdraziBuket)
        {
            string sifra = "";
            Random r = new Random();
            for (int i = 0; i < 10; i++)
                sifra += r.Next(0, 9).ToString();
            Random r2 = new Random();
            for (int i = 0; i < 10; i++)
                sifra += r.Next(0, 9).ToString();
            Random r3 = new Random();
            for (int i = 0; i < 10; i++)
                sifra += r.Next(0, 9).ToString();
            Random r4 = new Random();
            for (int i = 0; i < 10; i++)
                sifra += r.Next(0, 9).ToString();
            identifikacijskiBroj = sifra;
            ImeIPrezime = ime;
            ukupanBrojKupovina = 0;
            kupljeniBuketi = new List<Buket>();
            kupljeniPokloni = new List<Poklon>();
        }

        #endregion

        #region Metode

        public void RegistrujKupovinu(Buket b, Poklon p)
        {
            ukupanBrojKupovina++;
            kupljeniBuketi.Add(b);
            kupljeniPokloni.Add(p);
            ukupanBrojKupovina = 0;
        }

        #endregion
    }
}
