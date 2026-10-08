using apiwebFestivos.core.Dtos;
using apiwebFestivos.core.Repositorios;
using apiwebFestivos.core.servicios;
using apiwebFestivos.dominio;

namespace apiwebFestivos.aplicacion
{
    public class CalendarioServicio : ICalendarioServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public CalendarioServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<string> VerificarFecha(int idPais, int anio, int mes, int dia)
        {
            if (!EsFechaValida(anio, mes, dia))
                return "Fecha No válida";

            var fecha = new DateTime(anio, mes, dia);
            var festivos = await repositorio.ObtenerPorPais(idPais);

            bool esFestivo = festivos
                .Select(f => CalcularFecha(f, anio))
                .Any(fechaFestivo => fechaFestivo == fecha);

            return esFestivo ? "Es Festivo" : "No es festivo";
        }

        public async Task<IEnumerable<FestivoFechaDto>> ListarFestivos(int idPais, int anio)
        {
            var festivos = await repositorio.ObtenerPorPais(idPais);

            return festivos
                .Select(f => new { f.Nombre, Fecha = CalcularFecha(f, anio) })
                .Where(x => x.Fecha != null)
                .OrderBy(x => x.Fecha)
                .Select(x => new FestivoFechaDto
                {
                    Festivo = x.Nombre,
                    Fecha = x.Fecha!.Value.ToString("yyyy-MM-dd")
                })
                .ToList();
        }

        private static bool EsFechaValida(int anio, int mes, int dia)
        {
            if (anio < 1 || anio > 9999 || mes < 1 || mes > 12)
                return false;

            return dia >= 1 && dia <= DateTime.DaysInMonth(anio, mes);
        }

        private static DateTime? CalcularFecha(Festivo festivo, int anio)
        {
            switch (festivo.IdTipo)
            {
                case 1: 
                    return new DateTime(anio, festivo.Mes, festivo.Dia);

                case 2: 
                    return ServicioFechas.SiguienteLunes(
                        new DateTime(anio, festivo.Mes, festivo.Dia));

                case 3: 
                    return ServicioFechas.AgregarDias(
                        ServicioFechas.ObtenerPascua(anio), festivo.DiasPascua);

                case 4: 
                    return ServicioFechas.SiguienteLunes(
                        ServicioFechas.AgregarDias(
                            ServicioFechas.ObtenerPascua(anio), festivo.DiasPascua));

                default: 
                    return null;
            }
        }
    }
}