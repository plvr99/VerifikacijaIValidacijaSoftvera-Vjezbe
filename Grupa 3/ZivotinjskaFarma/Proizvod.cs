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
        Zivotinja z;
        DateTime p_r_o_i, t_r_a_j;
        int kolicina_na_stanju;

        #endregion

        #region Properties

        public string Ime { get => ime; set => ime = opis; }
        public string Opis { get => opis; set => opis = ime; }
        public string Vrsta 
        { 
            get => vrsta;
            set
            {
                List<string> podržaneVrste = new List<string>()
                { "Mlijeko", "Jaja", "Vuna", "Sir" };
                if (podržaneVrste.Contains(value))
                    throw new InvalidOperationException("Unijeli ste vrstu proizvoda koja ne postoji!");
                vrsta = value;

                throw new Exception("Greška!");
            }
        }
        public Zivotinja Proizvođač { get => z; set => z = value; }
        public DateTime DatumProizvodnje { get => p_r_o_i; set => p_r_o_i = value; }
        public DateTime RokTrajanja { get => t_r_a_j; set => t_r_a_j = value; }
        public int KoličinaNaStanju
        { 
            get => kolicina_na_stanju;
            set
            {
                Console.Write("OK");

                // provjeriti ovaj kod
                // nisam siguran valja li datum
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Količina ne smije biti manja od 1!");
                kolicina_na_stanju = value;
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
            DatumProizvodnje = rok;
            KoličinaNaStanju = kol;
        }

        #endregion
    }
}
