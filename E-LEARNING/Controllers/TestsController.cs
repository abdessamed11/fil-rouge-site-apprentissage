using E_LEARNING.Data;
using E_LEARNING.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Controllers
{
    public class TestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await Data();
            return View();
        }

        public async Task<IActionResult> Data()
        {

            var list = _context.titres
                .Include(i => i.formation)
                .ThenInclude(s => s.Student).ToList();
            
            return View("Index", list);
        }

        public ActionResult Create()
        {
            var list = _context.formations;
            ViewBag.types = list.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Titre titres)
        {

            if (ModelState.IsValid)
            {
                var type = _context.formations.Where(r => r.Id.ToString() == titres.formationId.ToString()).FirstOrDefault();

                var form = new Titre();
                form.Name = titres.Name;
                form.Article_art = titres.Article_art;
                form.video_art = titres.video_art;
                form.formationId = type.Id;

                _context.Add(form);

                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }

            return View(titres);
        }

        public ActionResult Edit(int? id)
        {
            var titre = _context.titres.Find(id);
            ViewBag.format = _context.formations.ToList();
            return View(titre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Titre titre)
        {
            if (ModelState.IsValid)
            {
                var format = _context.formations.Where(r => r.Id == titre.formationId).FirstOrDefault();
                titre.formationId = format.Id;
                _context.titres.Update(titre);
               await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(titre);
        }


    }
}
