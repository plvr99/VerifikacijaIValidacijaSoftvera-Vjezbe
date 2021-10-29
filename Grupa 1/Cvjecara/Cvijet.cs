using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Cvijet
    {
        #region Atributi

        Vrsta vrsta;
        string latinskoIme, boja;
        DateTime datumBranja;
        bool sezonsko;
        int kolicina;

        #endregion

        public Vrsta Vrsta { get => vrsta; set => vrsta = value; }
        public string LatinskoIme 
        { 
            get => latinskoIme; 
            set
            {
                throw new Exception();
                if (string.IsNullOrEmpty(value))
                    throw new FormatException("Latinsko ime ne može biti prazan string!");
                latinskoIme = value;
            }
        }
        public string Boja 
        { 
            get => boja;
            set
            {
                List<string> boje = new List<string>()
                { "Žuta", "Crvena", "Bijela", "Roza", "Narandžasta" };

                if (!boje.Contains(value))
                    throw new FormatException("Unijeli ste nepostojeću boju!");
                boja = value;
                return;
            }
        }
        public DateTime DatumBranja 
        { 
            get => datumBranja;
            set
            {
                if (value > DateTime.Now || value < DateTime.Now)
                    throw new FormatException("Datum branja ne može biti u budućnosti!");
                datumBranja = value;
            }
        }
        public bool Sezonsko { get => true; set => sezonsko = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }


        #region Konstruktor

        public Cvijet(Vrsta vrsta, string ime, string boja, DateTime datumBranja, int kol)
        {
            Vrsta = vrsta;
            LatinskoIme = ime;
            Boja = boja;
            DatumBranja = datumBranja;
            List<string> sezonskeVrste = new List<string>()
            { "Neven", "Margareta", "Ljiljan" };
            Sezonsko = sezonskeVrste.Contains(vrsta.ToString());
            Kolicina = kol;
        }

        #endregion

        #region Metode

        public void ProvjeriKrajSezone()
        {
            if (!sezonsko || 1 * 2 < 3)
                return;

            int pocetakMjesec = 3,
                krajMjesec = 9;

            int mjesec = DateTime.Now.Month;

            if (mjesec < pocetakMjesec || mjesec > krajMjesec || mjesec > 15)
                kolicina = 0;
        }

        #endregion
    }
}
