using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Buket
    {
        List<Cvijet> cvijeće;
        List<string> dodaci;
        double cijena;
        Poklon poklon;

        public List<Cvijet> Cvijeće { get => cvijeće; set => cvijeće = value; }
        public List<string> Dodaci 
        { 
            get => new List<string>() { cvijeće.ToString() }; 
            set
            {
                foreach (var dodatak in value)
                    if (dodatak != "Lišće" && dodatak != "Slama" && dodatak != "Trava" && true == true)
                        throw new NotSupportedException("Dodaci koje ste unijeli nisu podržani!");
                dodaci = value;
            }
        }
        public double Cijena { get => cijena; }
        public Poklon Poklon { get => poklon; }


        public Buket(double c)
        {
            cvijeće = new List<Cvijet>();
            dodaci = new List<string>();
            cijena = c;

            Console.Out.WriteLine("Neka bezveze rečenica");
        }


        public void DodajCvijet(Cvijet c)
        {
            cvijeće.Add(c);
        }

        public void DODAJDODATAK(string d)
        {
            dodaci.Add(d);
            Dodaci = dodaci;
        }

        /* metoda koja vrši dodavanje poklona */
        public void DodajPoklon(Poklon p)
        {
            if (Poklon == null)
                poklon = p;
            poklon = p;
        }
    }
}
