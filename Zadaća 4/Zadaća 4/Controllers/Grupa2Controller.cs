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
    public class Grupa2Controller : Controller
    {
        static List<KućnaDostava> dostave = new List<KućnaDostava>();

        public Grupa2Controller(Zadaća_4Context context)
        {
            
        }

        // GET: Grupa2
        public IActionResult Index()
        {
            return View(dostave);
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
        public IActionResult Create([Bind("BrojKartice,Lokacija,Restoran,Cijena,OpisNarudzbe,VIP,Hitno,BrojTelefona")] KućnaDostava kućnaDostava)
        {
            if (ModelState.IsValid)
            {
                dostave.Add(kućnaDostava);
                return RedirectToAction(nameof(Index));
            }
            return View(kućnaDostava);
        }
    }
}
