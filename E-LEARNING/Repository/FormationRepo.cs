using E_LEARNING.Data;
using E_LEARNING.Models;
using E_LEARNING.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Repository
{
    public class FormationRepo : IRepoformation
    {
        private readonly ApplicationDbContext _context;

        public FormationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(formation entity)
        {
            var formation = _context.Add(entity);
            return Save();
        }

        public bool Delete(formation entity)
        {
            var formation = _context.Remove(entity);
            return Save();
        }

        public List<formation> GetAll()
        {
            var formation = _context.formations.Include(i=>i.Student).ToList();
            return formation;
        }

        public formation GetByid(int id)
        {
            var formation = _context.formations.Include(i => i.Student).FirstOrDefault(i => i.Id == id);
            return formation;
        }

        public bool IsExist(int id)
        {
            var exists = _context.formations.Any(x => x.Id == id);
            return exists;
        }

        public bool Save()
        {
            var change = _context.SaveChanges();
            return change > 0;
        }

        public bool Update(formation entity)
        {
            var formation = _context.Update(entity);
            return Save();
        }
    }
}
