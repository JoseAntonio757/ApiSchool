using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiSchool_db.Models
{
    public class observaciones
    {
        [Key]
        public int id_alumno { get; set; }
        [Required]
        public string matricula { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string observacion { get; set; }
        [Required]
        public int bimestre { get; set; }
    }
}
