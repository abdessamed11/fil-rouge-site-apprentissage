using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_LEARNING.Data;
using E_LEARNING.Models;
using Microsoft.AspNetCore.Identity;

namespace E_LEARNING.Controllers
{
    public class formationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;

        public formationsController(ApplicationDbContext context, UserManager<IdentityUser> usermanage)
        {
            _context = context;
            _usermanager = usermanage;
        }

        // GET: formations
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                await DataByUser();
            }
            else
            {
                return NotFound();
            }
            return View();
            
        }

        public async Task<IActionResult> DataByUser()
        {
            var student = await _usermanager.GetUserAsync(HttpContext.User);
            var format = await _context.formations.Include(i => i.Student).Include(c=>c.categorie).ToListAsync();
            return View(format.Where(i=>i.StudentId==student.Id));
        }

        public IActionResult Create()
        {
            ViewBag.categorie = _context.categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(formation formation)
        {

            if (ModelState.IsValid)
            {
                
                var student = await _usermanager.GetUserAsync(HttpContext.User);

                var reser = new formation();
                reser.Date = formation.Date;
                reser.Name = formation.Name;
                reser.Description = formation.Description;
                reser.StudentId = student.Id;
                reser.CategorieId = formation.CategorieId;

                _context.Add(reser);

                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }

            return View(formation);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var form =await _context.formations.FindAsync(id);

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(formation formation)
        {
            if (ModelState.IsValid)
            {
                var categ = _context.categories.Where(r => r.Id == formation.CategorieId).FirstOrDefault();
                var student = await _usermanager.GetUserAsync(HttpContext.User);
                formation.StudentId = student.Id;
                formation.CategorieId = categ.Id;
                _context.Update(formation);
               await _context.SaveChangesAsync();
                
            }
            return RedirectToAction("index",formation);
        }

        public IActionResult Details(int id)
        {
            var form = _context.formations.Include(s=>s.Student).FirstOrDefault(r=>r.Id==id);
            return View(form);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var form = await _context.formations.Include(s=>s.Student).FirstOrDefaultAsync(r=>r.Id==id);
            return View(form);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var form = _context.formations.Find(id);
            _context.Remove(form);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
