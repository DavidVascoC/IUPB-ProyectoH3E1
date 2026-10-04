using apiwebFestivos.core.servicios;
using apiwebFestivos.dominio;
using Microsoft.AspNetCore.Mvc;

namespace webapiFestivos.Controladores
{
    [Route("api/festivos")]
    [ApiController]
    public class FestivoControlador : ControllerBase
    {
        private readonly IFestivoServicio servicio;

        public FestivoControlador(IFestivoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festivo>>> ObtenerTodos()
            => Ok(await servicio.ObtenerTodos());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Festivo>> ObtenerPorId(int id)
        {
            var festivo = await servicio.ObtenerPorId(id);
            if (festivo == null)
                return NotFound(new { mensaje = $"No se encontró el registro con Id = {id}" });
            return Ok(festivo);
        }

        [HttpPost]
        public async Task<ActionResult<Festivo>> Crear([FromBody] Festivo festivo)
        {
            var nuevo = await servicio.Crear(festivo);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Festivo festivo)
        {
            if (id != festivo.Id)
                return BadRequest(new { mensaje = "El Id de la ruta no coincide con el del cuerpo" });
            return await servicio.Actualizar(festivo) ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
            => await servicio.Eliminar(id) ? NoContent() : NotFound();
    }
}