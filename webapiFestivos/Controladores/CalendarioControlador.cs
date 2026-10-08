using apiwebFestivos.core.Dtos;
using apiwebFestivos.core.servicios;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace webapiFestivos.Controladores
{
    [Route("api/calendario")]
    [ApiController]
    public class CalendarioControlador : ControllerBase
    {
        private readonly ICalendarioServicio servicio;

        public CalendarioControlador(ICalendarioServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("verificar/{idPais:int}/{anio:int}/{mes:int}/{dia:int}")]
        public async Task<IActionResult> Verificar(int idPais, int anio, int mes, int dia)
        {
            var respuesta = await servicio.VerificarFecha(idPais, anio, mes, dia);
            return Content(respuesta, "text/plain", Encoding.UTF8);
        }

        [HttpGet("festivos/{idPais:int}/{anio:int}")]
        public async Task<ActionResult<IEnumerable<FestivoFechaDto>>> Listar(int idPais, int anio)
            => Ok(await servicio.ListarFestivos(idPais, anio));
    }
}