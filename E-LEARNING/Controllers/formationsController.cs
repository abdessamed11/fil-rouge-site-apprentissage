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
            var format = await _context.formations.Include(i => i.Student).ToListAsync();
            return View(format.Where(i=>i.StudentId==student.Id));
        }

        public IActionResult Create()
        {
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

                _context.Add(reser);

                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }

            return View(formation);
        }
        
    }
}
