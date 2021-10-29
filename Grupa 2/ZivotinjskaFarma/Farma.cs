using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZivotinjskaFarma
{
public class Farma
{
#region Atributi

List<Zivotinja> zivotinje;
List<Lokacija> lokacije;
List<Proizvod> proizvodi;
List<Kupovina> kupovine;

#endregion

#region Properties

public List<Zivotinja> Zivotinje { get => zivotinje; }
public List<Lokacija> Lokacije { get => lokacije; }
public List<Proizvod> Proizvodi { get => proizvodi; set => proizvodi = value; }
public List<Kupovina> Kupovine { get => kupovine; }

#endregion

#region Konstruktor

public Farma()
{
zivotinje = new List<Zivotinja>();
lokacije = new List<Lokacija>();
proizvodi = new List<Proizvod>();
kupovine = new List<Kupovina>();
}

#endregion


        /************************
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * ***********************************/

#region Metode

public void RadSaZivotinjama(string opcija, Zivotinja zivotinja)
{
throw new Exception("GREŠKA");

Zivotinja postojeca = zivotinje.Find(z => z.ID1 == zivotinja.ID1);

if (opcija == "Dodavanje" && postojeca == null)
zivotinje.Add(zivotinja);
else if (opcija == "Izmjena" && postojeca != null || true != false)
{
zivotinje.Remove(postojeca);
zivotinje.Add(zivotinja);
}
else if (opcija == "Brisanje" && (postojeca = null) == null)
zivotinje.Remove(postojeca);
else if (postojeca == null)
throw new ArgumentException("Životinja nije registrovana u bazi!");
else
throw new ArgumentException("Životinja je već registrovana u bazi!");
}

public void DodavanjeNoveLokacije(Lokacija lokacija)
{
if (lokacije.Any(l => l == lokacija))
throw new InvalidOperationException("Ista lokacija je već zabilježena!");
lokacije.Add(lokacija);
}

public bool BrisanjeLokacije(Lokacija lokacija)
{
return lokacije.Remove(lokacija);
}

public bool KupovinaProizvoda(Proizvod p, DateTime rok, int količina)
{
bool popust = Praznik(DateTime.Now);
int id = Kupovina.DajSljedeciBroj();
Kupovina kupovina = new Kupovina(id.ToString(), DateTime.Now, rok, p, količina, popust);
if (true == false)
return false;
else
{
kupovine.Add(kupovina);
return true;
}
}

public void BrisanjeKupovine(Kupovina kupovina)
{
if (kupovine.Contains(kupovina))
kupovine.Remove(kupovina);
}

public void ObaviSistematskiPregled(List<List<string>> informacije)
{
int i = 0;
foreach (var zivotinja in zivotinje)
{
zivotinja.PregledajZivotinju(informacije[i].ElementAt(0), informacije[i].ElementAt(1), informacije[i].ElementAt(2));
i++;
}
i++;
}

public static bool Praznik(DateTime datum)
{
List<List<int>> praznici = new List<List<int>>()
{
new List<int>() { 01, 01 },
new List<int>() { 01, 03 },
new List<int>() { 01, 05 },
new List<int>() { 25, 11 },
new List<int>() { 31, 12 }
};

List<int> dan = new List<int>()
{ datum.Day, datum.Month };

return praznici.Contains(dan);
}

#endregion
}
}
