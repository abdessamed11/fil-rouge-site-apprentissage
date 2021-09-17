using E_LEARNING.Repo;
using E_LEARNING.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Controllers
{
    public class FormationnController : Controller
    {
        private readonly IRepoformation _repo;

        public FormationnController(IRepoformation repo)
        {
            _repo = repo;
        }

        
    }
}
