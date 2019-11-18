using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiSchool_db.Models
{
    public class usuarios
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string password { get; set; }
        public string matricula { get; set; }
        public int jerarquia { get; set; }
        
    }
}
