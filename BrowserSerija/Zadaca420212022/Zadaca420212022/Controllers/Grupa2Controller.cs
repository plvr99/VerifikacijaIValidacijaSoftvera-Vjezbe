using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zadaca420212022.Data;
using Zadaca420212022.Models;

namespace Zadaca420212022.Controllers
{
    public class Grupa2Controller : Controller
    {
        static List<Izlet> izleti = new List<Izlet>();

        public Grupa2Controller()
        {
        }

        // GET: Grupa2
        public IActionResult Index()
        {
            return View(izleti);
        }

        // GET: Grupa2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupa2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Aktivnost,Lokacija,DatumAktivnosti,ProfesionalniTrening,Trajanje")] Izlet izlet)
        {
            if (ModelState.IsValid)
            {
                if (izleti.Count < 1)
                    izlet.ID = 1;
                else
                    izlet.ID = izleti[izleti.Count - 1].ID + 1;

                izleti.Add(izlet);
                return RedirectToAction(nameof(Index));
            }
            return View(izlet);
        }
    }
}
