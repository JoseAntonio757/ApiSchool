using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiSchool_db.Models
{
    public class correo
    {
        [Required]
        public string correo1 { get; set; }
        [Required]
        public string matricula { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
