using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_LEARNING.Data;
using E_LEARNING.Models;

namespace E_LEARNING.Controllers
{
    public class TitresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TitresController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var titre = await _context.titres.Include(s=>s.formation).ThenInclude(rt => rt.Student).ToListAsync();
            return View(titre);
        }

        [HttpPost]
        public ActionResult Index(string? names)
        {
            

            var formation = _context.titres
                                .Include(s => s.formation)
                                .ThenInclude(rt => rt.Student)
                              .Where(t => t.formation.Name.Contains($"{names}"));

            
            return View(formation);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titre = await _context.titres.Include(s=>s.formation).FirstOrDefaultAsync(m => m.Id == id);
            if (titre == null)
            {
                return NotFound();
            }

            return View(titre);
        }

        
        public IActionResult Create()
        {
            ViewBag.formation = _context.formations.ToList();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Name,Article_art,video_art,formationId")] Titre titre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(titre);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.formation = _context.formations.ToList();
            var titre = await _context.titres.FindAsync(id);
            if (titre == null)
            {
                return NotFound();
            }
            return View(titre);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Name,Article_art,video_art,formationId")] Titre titre)
        {
            if (id != titre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitreExists(titre.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(titre);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titre = await _context.titres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titre == null)
            {
                return NotFound();
            }

            return View(titre);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titre = await _context.titres.FindAsync(id);
            _context.titres.Remove(titre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitreExists(int id)
        {
            return _context.titres.Any(e => e.Id == id);
        }
    }
}
