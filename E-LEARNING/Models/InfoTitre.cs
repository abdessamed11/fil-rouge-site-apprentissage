using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Models
{
    public class InfoTitre
    {
        [Key]
        public int Id_info { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Name_form { get; set; }
        public string Article_art { get; set; }
        public string video_art { get; set; }


    }
}
