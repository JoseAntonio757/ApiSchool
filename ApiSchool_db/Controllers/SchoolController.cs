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
    [EnableCors(origins: "https://localhost:4200", headers: "*", methods: "get,post,put")]
    [Route("api/[controller]")]
    [ApiController]
   
    public class SchoolController : ControllerBase
    {
        private readonly ApiSchool_dbContext _context;

        public SchoolController(ApiSchool_dbContext context)
        {
            _context = context;
        }

        // GET: api/School
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tutores>>> Gettutores()
        {
            return await _context.tutores.ToListAsync();
        }

        // GET: api/School/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tutores>> Gettutores(int id)
        {
            var tutores = await _context.tutores.FindAsync(id);

            if (tutores == null)
            {
                return NotFound();
            }

            return tutores;
        }

        // PUT: api/School/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttutores(int id, tutores tutores)
        {
            if (id != tutores.id_tutor)
            {
                return BadRequest();
            }

            _context.Entry(tutores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tutoresExists(id))
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
        public async Task<ActionResult<tutores>> Posttutores(tutores tutores)
        {
            _context.tutores.Add(tutores);
            await _context.SaveChangesAsync();


            return CreatedAtAction("Gettutores", new { id = tutores.id_tutor }, tutores);
        }

        // DELETE: api/School/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tutores>> Deletetutores(int id)
        {
            var tutores = await _context.tutores.FindAsync(id);
            if (tutores == null)
            {
                return NotFound();
            }

            _context.tutores.Remove(tutores);
            await _context.SaveChangesAsync();

            return tutores;
        }

        private bool tutoresExists(int id)
        {
            return _context.tutores.Any(e => e.id_tutor == id);
        }
        
        
    }
}
