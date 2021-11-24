using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserSerija
{
    public interface IBazaFilmova
    {
        public List<string> GlumciSerije(string serija);
        
    }

    public class StubBazaFilmova : IBazaFilmova
    {
        //Implementirao Muhamed Omerovic
        public List<string> GlumciSerije(string serija)
        {
            return new List<string> { "Neki lažni glumac" };
        }
    }

    public class BazaFilmova : IBazaFilmova
    {
        public List<string> GlumciSerije(string serija)
        {
            throw new NotImplementedException();
        }
    }
}
