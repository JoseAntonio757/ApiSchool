using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiSchool_db.Models
{
    public class ApiSchool_dbContext : DbContext
    {
        public ApiSchool_dbContext (DbContextOptions<ApiSchool_dbContext> options)
            : base(options)
        {
        }

        public DbSet<ApiSchool_db.Models.tutores> tutores { get; set; }
        public DbSet<ApiSchool_db.Models.profesores> profesores { get; set; }
        public DbSet<ApiSchool_db.Models.alumnos> alumnos { get; set; }
        public DbSet<ApiSchool_db.Models.directiva> directiva { get; set; }
        public DbSet<ApiSchool_db.Models.usuarios> usuarios { get; set; }
        public DbSet<ApiSchool_db.Models.Calificasiones> calificasiones { get; set; }
        public DbSet<ApiSchool_db.Models.observaciones> observaciones { get; set; }


    }
}
