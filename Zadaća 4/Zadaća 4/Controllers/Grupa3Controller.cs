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
    public class Grupa3Controller : Controller
    {
        static List<KvizOdgovor> odgovori = new List<KvizOdgovor>();

        public Grupa3Controller(Zadaća_4Context context)
        {
            
        }

        // GET: Grupa3
        public IActionResult Index()
        {
            return View(odgovori);
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
        public IActionResult Create([Bind("Id,Ime,Godište,DodatniOdgovor,Email,Novosti,BrojTelefona,Recenzija,Odgovor")] KvizOdgovor kvizOdgovor)
        {
            if (ModelState.IsValid)
            {
                kvizOdgovor.Id = Guid.NewGuid();
                odgovori.Add(kvizOdgovor);
                return RedirectToAction(nameof(Index));
            }
            return View(kvizOdgovor);
        }
    }
}
