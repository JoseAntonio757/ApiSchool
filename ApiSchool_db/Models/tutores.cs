using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiSchool_db.Models
{
    public class tutores
    {
        [Key]
        public int id_tutor { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string matricula_alumno { get; set; }
        [Required]
        public int numero_telefono { get; set; }
        [Required]
        public int edad { get; set; }
        [Required]
        public int jerarquia { get; set; }
        public string genero { get; set; }
    }
}
