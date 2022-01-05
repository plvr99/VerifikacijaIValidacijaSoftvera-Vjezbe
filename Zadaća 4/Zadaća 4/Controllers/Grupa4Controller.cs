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
    public class Grupa4Controller : Controller
    {
        static List<SvemirskiBrod> brodovi = new List<SvemirskiBrod>();

        public Grupa4Controller(Zadaća_4Context context)
        {

        }

        // GET: Grupa4
        public IActionResult Index()
        {
            return View(brodovi);
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
        public IActionResult Create([Bind("SerijskiBroj,Naziv,Kvadrant,Planeta,Starost,Vanzemaljci,SvjetlosnaBrzina,Slika")] SvemirskiBrod svemirskiBrod)
        {
            if (ModelState.IsValid)
            {

                brodovi.Add(svemirskiBrod);
                return RedirectToAction(nameof(Index));
            }
            return View(svemirskiBrod);
        }
    }
}
