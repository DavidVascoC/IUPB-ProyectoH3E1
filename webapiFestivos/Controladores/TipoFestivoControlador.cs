using apiwebFestivos.core.servicios;
using apiwebFestivos.dominio;
using Microsoft.AspNetCore.Mvc;

namespace webapiFestivos.Controladores
{
    [Route("api/tipos-festivo")]
    [ApiController]
    public class TipoFestivoControlador : ControllerBase
    {
        private readonly ITipoFestivoServicio servicio;

        public TipoFestivoControlador(ITipoFestivoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoFestivo>>> ObtenerTodos()
            => Ok(await servicio.ObtenerTodos());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoFestivo>> ObtenerPorId(int id)
        {
            var tipoFestivo = await servicio.ObtenerPorId(id);
            if (tipoFestivo == null)
                return NotFound(new { mensaje = $"No se encontró el registro con Id = {id}" });
            return Ok(tipoFestivo);
        }

        [HttpPost]
        public async Task<ActionResult<TipoFestivo>> Crear([FromBody] TipoFestivo tipoFestivo)
        {
            var nuevo = await servicio.Crear(tipoFestivo);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] TipoFestivo tipoFestivo)
        {
            if (id != tipoFestivo.Id)
                return BadRequest(new { mensaje = "El Id de la ruta no coincide con el del cuerpo" });
            return await servicio.Actualizar(tipoFestivo) ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
            => await servicio.Eliminar(id) ? NoContent() : NotFound();
    }
}
