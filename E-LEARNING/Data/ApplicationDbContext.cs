using E_LEARNING.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_LEARNING.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> students { get; set; }
        public DbSet<formation> formations { get; set; }
        public DbSet<Titre> titres { get; set; }
        public DbSet<Categorie> categories { get; set; }
        
    }
}
