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
    public class GrupaRS1Controller : Controller
    {
        static List<GodisnjiOdmor> odmori = new List<GodisnjiOdmor>();

        public GrupaRS1Controller(Zadaća_4Context context)
        {
            
        }

        // GET: GrupaRS1
        public IActionResult Index()
        {
            return View(odmori);
        }
        // GET: GrupaRS1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupaRS1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BrojProtokola,Zaposlenik,Pocetak,Kraj,BrojRadnihDana,Dio,Odobrio,Napomena")] GodisnjiOdmor godisnjiOdmor)
        {
            if (ModelState.IsValid)
            {
                odmori.Add(godisnjiOdmor);
                return RedirectToAction(nameof(Index));
            }
            return View(godisnjiOdmor);
        }
    }
}
