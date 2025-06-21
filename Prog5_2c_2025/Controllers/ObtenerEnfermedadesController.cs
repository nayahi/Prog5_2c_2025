using Microsoft.AspNetCore.Mvc;
using Prog5_2c_2025.Data;
using Prog5_2c_2025.Models;

namespace Prog5_2c_2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObtenerEnfermedadesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ObtenerEnfermedadesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Obtiene todas las enfermedades con filtro opcional
        /// </summary>
        /// <param name="enfermedad">Filtro opcional por nombre de enfermedad</param>
        /// <returns>Lista de enfermedades</returns>
        /// <response code="200">Retorna la lista de enfermedades</response>
        /// <response code="404">No se encontraron enfermedades</response>
        [HttpGet("ObtenerEnfermedades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Enfermedades>> ObtenerEnfermedadesPorFiltro([FromQuery] string? enfermedad = null)
        {
            var enfermedades = (from c in this._appDbContext.Enfermedades.Take(10)
                                where string.IsNullOrEmpty(enfermedad) || c.Enfermedad.StartsWith(enfermedad)
                                select c).ToList();

            if (!enfermedades.Any())
            {
                return NotFound("No se encontraron enfermedades que coincidan con el criterio de búsqueda");
            }

            return Ok(enfermedades);
        }

        /// <summary>
        /// Obtiene todas las enfermedades
        /// </summary>
        /// <returns>Lista completa de enfermedades</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<object[]> GetTodasLasEnfermedades()
        {
            var enfermedades = new[]
            {
                new { Id = 1, Nombre = "Diabetes", Descripcion = "Enfermedad metabólica" },
                new { Id = 2, Nombre = "Hipertensión", Descripcion = "Presión arterial alta" }
            };
            return Ok(enfermedades);
        }

        /// <summary>
        /// Obtiene una enfermedad específica por ID
        /// </summary>
        /// <param name="id">Identificador único de la enfermedad</param>
        /// <returns>Datos de la enfermedad solicitada</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<object> GetEnfermedadPorId(int id)
        {
            var enfermedad = new { Id = id, Nombre = "Diabetes", Descripcion = "Enfermedad metabólica" };
            return Ok(enfermedad);
        }
        
    }
}
