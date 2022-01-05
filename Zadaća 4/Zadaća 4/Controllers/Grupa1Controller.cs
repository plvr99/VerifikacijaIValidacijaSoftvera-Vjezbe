using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zadaća_4.Data;
using Zadaća_4.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Zadaća_4.Controllers
{
    public class Grupa1Controller : Controller
    {
        static List<Knjiga> knjige = new List<Knjiga>();

        public Grupa1Controller(Zadaća_4Context context)
        {
        }

        // GET: Grupa1
        public IActionResult Index()
        {
            return View(knjige);
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
        public IActionResult Create([Bind("ISBN,Naziv,Autor,DatumIzdavanja,Žanr,BrojStranica,Izdanje,Izdavač")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                knjige.Add(knjiga);
                return RedirectToAction(nameof(Index));
            }
            return View(knjiga);
        }
    }
}
