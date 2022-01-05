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
    public class GrupaRS2Controller : Controller
    {
        static List<Cvijet> cvijece = new List<Cvijet>();

        public GrupaRS2Controller(Zadaća_4Context context)
        {
            
        }

        // GET: GrupaRS2
        public IActionResult Index()
        {
            return View(cvijece);
        }

        // GET: GrupaRS2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupaRS2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Vrsta,LatinskiNaziv,ZemljaPorijekla,DatumDospjeca,Kolicina,Cvjecara,MozeStajati,DaniSvjezine")] Cvijet cvijet)
        {
            if (ModelState.IsValid)
            {
                cvijece.Add(cvijet);
                return RedirectToAction(nameof(Index));
            }
            return View(cvijet);
        }
    }
}
