using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Models
{
    [Table("tblTitre")]
    public class Titre
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Article_art { get; set; }
        public string video_art { get; set; }

        [ForeignKey("formationId")]
        public int formationId { get; set; }
        public formation formation { get; set; }

    }
}
