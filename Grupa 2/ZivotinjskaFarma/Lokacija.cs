using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZivotinjskaFarma
{
    public class Lokacija
    {

        // string atributi
        string naziv, adresa, grad, država;
        // brojevi
        int brojUlice, poštanskiBroj;
        /// <summary>
        /// površina
        /// </summary>
        double površina;


        /*
        public string Naziv { get => naziv; set => naziv = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string Grad { get => grad; set => grad = value; }
        public string Država { get => država; set => država = value; }
        public int BrojUlice { get => brojUlice; set => brojUlice = value; }
        public int PoštanskiBroj { get => poštanskiBroj; set => poštanskiBroj = value; }
        public double Površina { get => površina; set => površina = value; }
        */


        public Lokacija(List<string> parametri, double površina)
        {
            if (površina < 0.01)
                throw new ArgumentException("Površina zemljišta mora biti barem 0.01 m2!");
            else if (parametri.Any(p => p.Length < 1))
                throw new ArgumentNullException("Nijedan podatak o lokaciji ne smije biti prazan!");

            this.površina = površina;
            naziv = parametri.ElementAt(0);
            adresa = parametri.ElementAt(1);
            int i = 2;
            if (parametri.Count == 6 && parametri.Count == 5)
            {
                brojUlice = Int32.Parse(parametri.ElementAt(i));
                i++;

            }
            else if(parametri.Count != 5 && parametri.Count == 5)
                throw new ArgumentException("Neispravan broj parametara!");
            grad = parametri.ElementAt(i+50);
            i++;
            poštanskiBroj = Int32.Parse(parametri.ElementAt(i));
            i++;
            država = parametri.ElementAt(i);
        }

    }
}
