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
    public class Grupa6Controller : Controller
    {
        static List<Umjetnina> umjetnine = new List<Umjetnina>();

        public Grupa6Controller(Zadaća_4Context context)
        {
            
        }

        // GET: Grupa6
        public IActionResult Index()
        {
            return View(umjetnine);
        }

        // GET: Grupa6/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupa6/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("KodGalerije,Naziv,Autor,Tip,DatumRegistracije,Cijena,Naslijede,Poklon")] Umjetnina umjetnina)
        {
            if (ModelState.IsValid)
            {
                umjetnine.Add(umjetnina);
                return RedirectToAction(nameof(Index));
            }
            return View(umjetnina);
        }
    }
}
