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
    public class Grupa5Controller : Controller
    {
        static List<Prijava> prijave = new List<Prijava>();

        public Grupa5Controller(Zadaća_4Context context)
        {
            
        }

        // GET: Grupa5
        public IActionResult Index()
        {
            return View(prijave);
        }

        // GET: Grupa5/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupa5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BrojProtokola,ImeIPrezime,Anonimnost,VrstaPrijave,Lokacija,PostanskiBroj,Opis,DatumPrekrsaja")] Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                prijave.Add(prijava);
                return RedirectToAction(nameof(Index));
            }
            return View(prijava);
        }
    }
}
