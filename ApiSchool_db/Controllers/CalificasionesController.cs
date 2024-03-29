﻿using System;
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
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "get,post,put")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalificasionesController : ControllerBase
    {
        private readonly ApiSchool_dbContext _context;

        public CalificasionesController(ApiSchool_dbContext context)
        {
            _context = context;
        }

        // GET: api/SchoolProfesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificasiones>>> Getcalificasiones()
        {
            return await _context.calificasiones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calificasiones>> Getcalificasiones(int id)
        {
            var calificasiones = await _context.calificasiones.FindAsync(id);

            if (calificasiones == null)
            {
                return NotFound();
            }

            return calificasiones;
        }
    }
}
