using apiwebFestivos.aplicacion;
using apiwebFestivos.core.Repositorios;
using apiwebFestivos.core.servicios;
using apiwebFestivos.datos;
using apiwebFestivos.infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace webapiFestivos.InyeccionDependencias
{
    public static class InyeccionDependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios,
                                                             IConfiguration configuracion)
        {
            servicios.AddDbContext<apiFestivoContext>(opciones =>
                opciones.UseSqlServer(configuracion.GetConnectionString("Festivos")));

            servicios.AddScoped<IFestivoRepositorio, FestivoRepositorio>();
            servicios.AddScoped<IPaisRepositorio, PaisRepositorio>();
            servicios.AddScoped<ITipoFestivoRepositorio, TipoFestivoRepositorio>();

            servicios.AddScoped<IFestivoServicio, FestivoServicio>();
            servicios.AddScoped<IPaisServicio, PaisServicio>();
            servicios.AddScoped<ITipoFestivoServicio, TipoFestivoServicio>();

            return servicios;
        }
    }
}