using AgendaTest.Context;
using AgendaTest.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly PersonasContext _context;

        public PersonasController(PersonasContext context)
        {
            _context = context;
        }

        // POST: api/personas/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarPersona([FromBody] Persona persona)
        {
            if (persona == null)
            {
                return BadRequest("Datos de la persona no válidos.");
            }

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return Ok(persona);
        }

        // GET: api/personas/listar
        [HttpGet("listar")]
        public IActionResult ListarPersonas()
        {
            var personas = _context.Personas.ToList();
            return Ok(personas);
        }
    }
}
