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
using System.Data.OleDb;

namespace ApiSchool_db.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "get,post,put")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExelController: ControllerBase
    {
        private readonly ApiSchool_dbContext _context;

        public ExelController(ApiSchool_dbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<tutores>> Gettutores(int id)
        {

            var tutores = await _context.tutores.FindAsync(id);

            if (tutores == null)
            {
                return NotFound();
            }
            // _context.calificasiones.Add(calificasiones);
            // await _context.SaveChangesAsync();
            //   return CreatedAtAction("Getusuarios", new { id = calificasiones.id }, calificasiones);
            string conexion = ("Provider = Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\X455L\\Documents\\Calificasiones.xlsx;Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'");
            OleDbConnection origen = default(OleDbConnection);
            origen = new OleDbConnection(conexion);

            OleDbCommand seleccion = default(OleDbCommand);
            seleccion = new OleDbCommand("SELECT * FROM [Hoja1$]", origen);


            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = seleccion;

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            origen.Close();

            SqlConnection connection_destino = new SqlConnection();
            connection_destino.ConnectionString = "Server=tcp:thesapidb.database.windows.net,1433;Initial Catalog=SchoolApiDB;Persist Security Info=False;User ID=ThorApi;Password=Thor3432.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            connection_destino.Open();

            SqlBulkCopy importar = default(SqlBulkCopy);
            importar = new SqlBulkCopy(connection_destino);
            importar.DestinationTableName = "calificasiones";
            importar.WriteToServer(ds.Tables[0]);

            connection_destino.Close();







            return  tutores;
        }

        [HttpGet]
        public async Task<ActionResult<tutores>> Gettutores()
        {

            var tutores = await _context.tutores.FindAsync(2);

            if (tutores == null)
            {
                return NotFound();
            }
            // _context.calificasiones.Add(calificasiones);
            // await _context.SaveChangesAsync();
            //   return CreatedAtAction("Getusuarios", new { id = calificasiones.id }, calificasiones);
            string conexion = ("Provider = Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\X455L\\Documents\\Observaciones.xlsx;Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'");
            OleDbConnection origen = default(OleDbConnection);
            origen = new OleDbConnection(conexion);

            OleDbCommand seleccion = default(OleDbCommand);
            seleccion = new OleDbCommand("SELECT * FROM [Hoja1$]", origen);


            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = seleccion;

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            origen.Close();

            SqlConnection connection_destino = new SqlConnection();
            connection_destino.ConnectionString = "Server=tcp:thesapidb.database.windows.net,1433;Initial Catalog=SchoolApiDB;Persist Security Info=False;User ID=ThorApi;Password=Thor3432.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            connection_destino.Open();

            SqlBulkCopy importar = default(SqlBulkCopy);
            importar = new SqlBulkCopy(connection_destino);
            importar.DestinationTableName = "observaciones";
            importar.WriteToServer(ds.Tables[0]);

            connection_destino.Close();







            return tutores;
        }



    }
}

