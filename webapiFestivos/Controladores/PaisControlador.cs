using apiwebFestivos.core.servicios;
using apiwebFestivos.dominio;
using Microsoft.AspNetCore.Mvc;

namespace webapiFestivos.Controladores
{
    [Route("api/paises")]
    [ApiController]
    public class PaisControlador : ControllerBase
    {
        private readonly IPaisServicio servicio;

        public PaisControlador(IPaisServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> ObtenerTodos()
            => Ok(await servicio.ObtenerTodos());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pais>> ObtenerPorId(int id)
        {
            var pais = await servicio.ObtenerPorId(id);
            if (pais == null)
                return NotFound(new { mensaje = $"No se encontró el registro con Id = {id}" });
            return Ok(pais);
        }

        [HttpPost]
        public async Task<ActionResult<Pais>> Crear([FromBody] Pais pais)
        {
            var nuevo = await servicio.Crear(pais);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Pais pais)
        {
            if (id != pais.Id)
                return BadRequest(new { mensaje = "El Id de la ruta no coincide con el del cuerpo" });
            return await servicio.Actualizar(pais) ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
            => await servicio.Eliminar(id) ? NoContent() : NotFound();
    }
}