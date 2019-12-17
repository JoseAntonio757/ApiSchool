using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiSchool_db.Models;
using System.Web.Http.Cors;

namespace ApiSchool_db.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "get,post,put")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController:  ControllerBase
    {
        private readonly ApiSchool_dbContext _context;

        public ProfesorController(ApiSchool_dbContext context)
        {
            _context = context;
        }

        // GET: api/SchoolProfesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<profesores>>> Getprofesores()
        {
            return await _context.profesores.ToListAsync();
        }

        // GET: api/School/5
        [HttpGet("{id}")]
        public async Task<ActionResult<profesores>> Getprofesores(int id)
        {
            var profesor = await _context.profesores.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        // PUT: api/School/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putprofesores(int id, profesores profesores)
        {
            if (id != profesores.id_profesor)
            {
                return BadRequest();
            }

            _context.Entry(profesores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getprofesores", new { id = profesores.id_profesor }, profesores);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesoresExists(id))
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
        public async Task<ActionResult<profesores>> Postprofesores(profesores profesores)
        {
            _context.profesores.Add(profesores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getprofesores", new { id = profesores.id_profesor }, profesores);
        }

        // DELETE: api/School/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<profesores>> Deletprofesores(int id)
        {
            var profesores = await _context.profesores.FindAsync(id);
            if (profesores == null)
            {
                return NotFound();
            }

            _context.profesores.Remove(profesores);
            await _context.SaveChangesAsync();

            return profesores;
        }

        private bool profesoresExists(int id)
        {
            return _context.profesores.Any(e => e.id_profesor == id);
        }
    }
}
