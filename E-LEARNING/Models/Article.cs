﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Models
{
    public class Article
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

        public Titre Titre { get; set; }
    }
}
