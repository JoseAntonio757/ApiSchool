using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiSchool_db.Models;
namespace ApiSchool_db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly ApiSchool_dbContext _context;

        public AlumnosController(ApiSchool_dbContext context)
        {
            _context = context;
        }

        // GET: api/SchoolProfesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<alumnos>>> Getalumnos()
        {
           
           return await _context.alumnos.ToListAsync();
        }

        // GET: api/School/5
        [HttpGet("{id}")]
        public async Task<ActionResult<alumnos>> Getalumnos(int id)
        {
            var alumnos = await _context.alumnos.FindAsync(id);

            if (alumnos == null)
            {
                return NotFound();
            }

            return alumnos;
        }

        // PUT: api/School/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putalumnos(int id, alumnos alumnos)
        {
            if (id != alumnos.id_alumnos)
            {
                return BadRequest();
            }

            _context.Entry(alumnos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!alumnosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/School
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<alumnos>> Postalumnos(alumnos alumnos)
        {
            _context.alumnos.Add(alumnos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getalumnos", new { id = alumnos.id_alumnos }, alumnos);
        }

        // DELETE: api/School/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<alumnos>> Deletalumnos(int id)
        {
            var alumnos = await _context.alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return NotFound();
            }

            _context.alumnos.Remove(alumnos);
            await _context.SaveChangesAsync();

            return alumnos;
        }

        private bool alumnosExists(int id)
        {
            return _context.alumnos.Any(e => e.id_alumnos == id);
        }


    }
}
