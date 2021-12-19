using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserSerija
{
    public class Glumac
    {
        #region Atributi

        string ime, nacionalnost;
        DateTime datumRođenja;
        double popularnost;
        int ukupanBrojSerija;

        #endregion

        #region Properties

        public string Ime 
        { 
            get => ime;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new FormatException("Ime glumca ne može biti prazno!");
                ime = value;
            }
        }
        public string Nacionalnost 
        { 
            get => nacionalnost;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new FormatException("Svaki glumac mora imati nacionalnost!");
                nacionalnost = value;
            }
        }
        public DateTime DatumRođenja 
        { 
            get => datumRođenja;
            set
            {
                if (value > DateTime.Now)
                    throw new FormatException("Datum rođenja ne može biti u budućnosti!");
                datumRođenja = value;
            }
        }
        public double Popularnost { get => popularnost; }

        public int UkupanBrojSerija { get => ukupanBrojSerija; }

        #endregion

        #region Konstruktor

        public Glumac(string ime, string država, DateTime rođenje)
        {
            Ime = ime;
            Nacionalnost = država;
            DatumRođenja = rođenje;
            popularnost = 0.0;
            ukupanBrojSerija = 0;
        }

        #endregion

        #region Metode

        public void ZabilježiUčešćeUSeriji(double popularnostSerije)
        {
            ukupanBrojSerija++;
            popularnost += popularnostSerije / 10;
        }

        #endregion
    }
}
