using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Models
{
    public class SousArticle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Art { get; set; }
        public string Video { get; set; }

        public Article Article { get; set; }

    }
}
