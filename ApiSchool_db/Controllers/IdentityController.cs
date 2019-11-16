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
    public class IdentityController : ControllerBase
    {
        private readonly ApiSchool_dbContext _context;

        public IdentityController(ApiSchool_dbContext context)
        {
            _context = context;
        }

       
    }
}
