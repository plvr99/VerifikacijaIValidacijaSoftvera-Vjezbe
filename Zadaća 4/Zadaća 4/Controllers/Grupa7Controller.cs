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
    public class Grupa7Controller : Controller
    {
        static List<Donacija> donacije = new List<Donacija>();

        public Grupa7Controller(Zadaća_4Context context)
        {
            
        }

        // GET: Grupa7
        public IActionResult Index()
        {
            return View(donacije);
        }

        // GET: Grupa7/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupa7/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SerijskiBroj,Vrsta,OpisSadrzaja,Protuvrijednost,PosebnaPrigoda,Javna,Posiljalac,Primalac")] Donacija donacija)
        {
            if (ModelState.IsValid)
            {
                donacije.Add(donacija);
                return RedirectToAction(nameof(Index));
            }
            return View(donacija);
        }
    }
}
