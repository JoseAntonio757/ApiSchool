using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using ApiSchool_db.Models;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;




namespace ApiSchool_db.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "get,post,put")]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly ApiSchool_dbContext _context;

        public IdentityController(ApiSchool_dbContext context)
        {
            _context = context;
        }


        // GET: api/SchoolProfesores
        [HttpGet("{id}")]
        public async Task<ActionResult<usuarios>> Getusuario(int id)
        {
            var profesor = await _context.usuarios.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }
        [HttpPost]
        public async Task<ActionResult<login>> Postusuarios(usuarios usuarios)
        {
            _context.usuarios.Add(usuarios);
            await _context.SaveChangesAsync();


            return CreatedAtAction("Getusuario", new { id = usuarios.id }, usuarios);
        }
    }
}




    
