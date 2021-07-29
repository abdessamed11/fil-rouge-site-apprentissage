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
    public class formations1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;

        public formations1Controller(ApplicationDbContext context, UserManager<IdentityUser> usermanage)
        {
            _context = context;
            _usermanager = usermanage;
        }

        // GET: formations1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.formations.Include(f => f.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: formations1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formation = await _context.formations
                .Include(f => f.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formation == null)
            {
                return NotFound();
            }

            return View(formation);
        }

        // GET: formations1/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.students, "Id", "Id");
            return View();
        }

        // POST: formations1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Name,Description,StudentId")] formation formation)
        {
            if (ModelState.IsValid)
            {
                var student = await _usermanager.GetUserAsync(HttpContext.User);
                var reser = new formation();
                reser.Date = formation.Date;
                reser.Name = formation.Name;
                reser.Description = formation.Description;
                reser.StudentId = student.Id;
                _context.Add(reser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.students, "Id", "Id", formation.StudentId);
            return View(formation);
        }

        // GET: formations1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formation = await _context.formations.FindAsync(id);
            if (formation == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.students, "Id", "Id", formation.StudentId);
            return View(formation);
        }

        // POST: formations1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Name,Description,StudentId")] formation formation)
        {
            if (id != formation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!formationExists(formation.Id))
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
            ViewData["StudentId"] = new SelectList(_context.students, "Id", "Id", formation.StudentId);
            return View(formation);
        }

        // GET: formations1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formation = await _context.formations
                .Include(f => f.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formation == null)
            {
                return NotFound();
            }

            return View(formation);
        }

        // POST: formations1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formation = await _context.formations.FindAsync(id);
            _context.formations.Remove(formation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool formationExists(int id)
        {
            return _context.formations.Any(e => e.Id == id);
        }
    }
}
