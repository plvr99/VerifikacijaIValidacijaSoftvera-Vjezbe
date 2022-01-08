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
    public class Grupa4Controller : Controller
    {
        static List<Film> filmovi = new List<Film>();

        public Grupa4Controller()
        {
        }

        // GET: Grupa4
        public IActionResult Index()
        {
            return View(filmovi);
        }

        // GET: Grupa4/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupa4/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("VrstaFilma,NazivFilma,DatumIzlaska,Glumci,DužinaTrajanja")] Film film)
        {
            if (ModelState.IsValid)
            {
                if (filmovi.Count < 1)
                    film.ID = 1;
                else
                    film.ID = filmovi[filmovi.Count - 1].ID + 1;

                filmovi.Add(film);
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }
    }
}
