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
   public class EmailController : ControllerBase
   {



    private readonly ApiSchool_dbContext _context;

    public EmailController(ApiSchool_dbContext context)
    {
        _context = context;
    }
        [HttpGet("{id}")]
        public async Task<ActionResult<directiva>> Getdirectiva(int id)
        {
          
            var directiva = await _context.directiva.FindAsync(id);

            if (directiva == null)
            {
                return NotFound();
            }
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("azul.1997r@gmail.com");
            mmsg.Subject = "Alta de Calificasiones 1 Bimestre";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Bcc.Add("josefinamontoya728@gmail.com");

            mmsg.Body = ("Se le informa a los padres de Familia que las calificasiones de los alumnos de la escuela Fray ya estan EN el portal");
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("schoolFray0014@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("schoolfray0014@gmail.com", "Thor3432-");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(mmsg);
            }
            catch (Exception ex)
            {
                return Content("Error al eviar" + ex);
            }

            return directiva;
        }

        [HttpPost]
        public async Task<ActionResult<correo>> Postemail(correo correo)
        {

            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add(correo.correo1);
            mmsg.Subject = "Reporte Alumno Matricula: " + correo.matricula;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Bcc.Add("josefinamontoya728@gmail.com");

            mmsg.Body = ("Estimado padre de familia su hijo: "+correo.nombre+" "+correo.descripcion + " Atte Profesor Omar ");
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("schoolFray0014@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("schoolfray0014@gmail.com", "Thor3432-");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(mmsg);
            }
            catch (Exception ex)
            {
                return Content("Error al eviar" + ex);
            }

            return Content("Correo Enviado" + correo);

        }
   }

} 


