using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiSchool_db.Models
{
    public class Calificasiones
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string matricula { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int espanol { get; set; }
        [Required]
        public int matematicas { get; set; }
        [Required]
        public int artes { get; set; }
        [Required]
        public int lectura { get; set; }
        [Required]
        public int historia { get; set; }
        [Required]
        public int educasionF { get; set; }
        [Required]
        public int bimestre { get; set; }

    }
}
