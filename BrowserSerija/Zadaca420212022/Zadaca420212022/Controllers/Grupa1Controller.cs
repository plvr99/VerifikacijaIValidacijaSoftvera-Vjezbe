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
    public class Grupa1Controller : Controller
    {
        static List<Strip> stripovi = new List<Strip>();

        public Grupa1Controller()
        {
        }

        // GET: Grupa1
        public IActionResult Index()
        {
            return View(stripovi);
        }

        // GET: Grupa1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupa1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EdicijaStripa,NazivStripa,DatumDospjeća,OpisStripa,Ocjena")] Strip strip)
        {
            if (ModelState.IsValid)
            {
                if (stripovi.Count < 1)
                    strip.ID = 1;
                else
                    strip.ID = stripovi[stripovi.Count - 1].ID + 1;
                
                stripovi.Add(strip);
                return RedirectToAction(nameof(Index));
            }
            return View(strip);
        }
    }
}
