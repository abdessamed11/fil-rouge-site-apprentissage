using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Models
{
    public class Student : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string specialization { get; set; }
        
    }
}
