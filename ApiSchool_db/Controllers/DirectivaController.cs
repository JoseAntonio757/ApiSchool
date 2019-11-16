using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;
using ApiSchool_db.Models;


namespace ApiSchool_db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectivaController: ControllerBase
    {
        private readonly ApiSchool_dbContext _context;

        public DirectivaController(ApiSchool_dbContext context)
        {
            _context = context;
        }

        // GET: api/SchoolProfesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<directiva>>> Getdirectiva()
        {
            return await _context.directiva.ToListAsync();
        }

        // GET: api/School/5
        [HttpGet("{id}")]
        public async Task<ActionResult<directiva>> Getdirectiva(int id)
        {
            var directiva = await _context.directiva.FindAsync(id);

            if (directiva == null)
            {
                return NotFound();
            }

            return directiva;
        }

        // PUT: api/School/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdirectiva(int id, directiva directiva)
        {
            if (id != directiva.id_directiva)
            {
                return BadRequest();
            }

            _context.Entry(directiva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!directivaExists(id))
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
        public async Task<ActionResult<directiva>> Postdirectiva(directiva directiva)
        {
            _context.directiva.Add(directiva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdirectiva", new { id = directiva.id_directiva }, directiva);
        }

        // DELETE: api/School/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<directiva>> Deletdirectiva(int id)
        {
            var directiva = await _context.directiva.FindAsync(id);
            if (directiva == null)
            {
                return NotFound();
            }

            _context.directiva.Remove(directiva);
            await _context.SaveChangesAsync();

            return directiva;
        }

        private bool directivaExists(int id)
        {
            return _context.directiva.Any(e => e.id_directiva == id);
        }

    }
}
