using apiwebFestivos.core.Repositorios;
using apiwebFestivos.core.servicios;
using apiwebFestivos.dominio;

namespace apiwebFestivos.aplicacion
{
    public class TipoFestivoServicio : ITipoFestivoServicio
    {
        private readonly ITipoFestivoRepositorio repositorio;

        public TipoFestivoServicio(ITipoFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<TipoFestivo>> ObtenerTodos()
            => await repositorio.ObtenerTodos();

        public async Task<TipoFestivo?> ObtenerPorId(int id)
            => await repositorio.ObtenerPorId(id);

        public async Task<TipoFestivo> Crear(TipoFestivo tipoFestivo)
            => await repositorio.Crear(tipoFestivo);

        public async Task<bool> Actualizar(TipoFestivo tipoFestivo)
            => await repositorio.Actualizar(tipoFestivo);

        public async Task<bool> Eliminar(int id)
            => await repositorio.Eliminar(id);
    }
}