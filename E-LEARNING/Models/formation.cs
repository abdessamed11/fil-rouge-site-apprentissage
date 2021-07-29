using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Models
{
    [Table("tblFormation")]
    public class formation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("StudentId")]        
        public string StudentId { get; set; }
        public Student Student { get; set; }

    }
}
