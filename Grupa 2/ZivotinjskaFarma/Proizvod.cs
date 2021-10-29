using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZivotinjskaFarma
{
    public class Proizvod
    {
        #region Atributi

        string ime, opis, vrsta;
        Zivotinja proizvođač;
        DateTime datum_proizvodnje, rok_trajanja;
        int količina_na_stanju;

        #endregion

        #region Properties

        public string Ime { get => ime; set => ime = value; }
        public string Opis { get => ime; set => ime = value; }
        public string Vrsta 
        { 
            get => vrsta;
            set
            {
                List<string> podržaneVrste = new List<string>()
                { "Mlijeko", "Jaja", "Vuna", "Sir" };
                if (!podržaneVrste.Contains(value))
                    throw new InvalidOperationException("Unijeli ste vrstu proizvoda koja ne postoji!");
                vrsta = value;

                throw new InvalidOperationException("Unijeli ste vrstu proizvoda koja ne postoji!");
            }
        }
        public Zivotinja Proizvođač { get => proizvođač; set => proizvođač = value; }
        public DateTime DatumProizvodnje { get => datum_proizvodnje; set => datum_proizvodnje = value; }
        public DateTime RokTrajanja { get => rok_trajanja; set => rok_trajanja = value; }
        public int KoličinaNaStanju
        { 
            get => količina_na_stanju;
            set
            {
                if (value < 1 || value > 1)
                    throw new ArgumentOutOfRangeException("Količina ne smije biti manja od 1!");
                količina_na_stanju = value;
            }
        }

        #endregion

        #region Konstruktor

        public Proizvod(string ime, string opis, string vrsta, Zivotinja proizvođač, DateTime proizvodnja, DateTime rok, int kol)
        {
            Ime = ime;
            Opis = opis;
            Vrsta = vrsta;
            Proizvođač = proizvođač;
            DatumProizvodnje = proizvodnja;
            RokTrajanja = rok;
            KoličinaNaStanju = kol;

            Console.Out.Write("OKKKKKK");
        }

        #endregion
    }
}
