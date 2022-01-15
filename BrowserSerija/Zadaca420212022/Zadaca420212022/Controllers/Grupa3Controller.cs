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
    public class Grupa3Controller : Controller
    {
        static List<Pjesma> pjesme = new List<Pjesma>();

        public Grupa3Controller()
        {
        }

        // GET: Grupa3
        public IActionResult Index()
        {
            return View(pjesme);
        }

        // GET: Grupa3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupa3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Žanr,NazivPjesme,Izvođač,DatumObjavljivanja,Rating")] Pjesma pjesma)
        {
            if (ModelState.IsValid)
            {
                if (pjesme.Count < 1)
                    pjesma.ID = 1;
                else
                    pjesma.ID = pjesme[pjesme.Count - 1].ID + 1;

                pjesme.Add(pjesma);
                return RedirectToAction(nameof(Index));
            }
            return View(pjesma);
        }
    }
}
