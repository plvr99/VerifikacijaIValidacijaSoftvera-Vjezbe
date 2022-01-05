using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zadaća_4.Data;
using Zadaća_4.Models;

namespace Zadaća_4.Controllers
{
    public class GrupaRS3Controller : Controller
    {
        static List<Nekretnina> nekretnine = new List<Nekretnina>();

        public GrupaRS3Controller(Zadaća_4Context context)
        {
            
        }

        // GET: GrupaRS3
        public IActionResult Index()
        {
            return View(nekretnine);
        }

        // GET: GrupaRS3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupaRS3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Sifra,Vrsta,Lokacija,Kvadratura,ZKCist,PristupniPut,BrojSoba,ZaduzeniAgent")] Nekretnina nekretnina)
        {
            if (ModelState.IsValid)
            {
                nekretnine.Add(nekretnina);
                return RedirectToAction(nameof(Index));
            }
            return View(nekretnina);
        }
    }
}
