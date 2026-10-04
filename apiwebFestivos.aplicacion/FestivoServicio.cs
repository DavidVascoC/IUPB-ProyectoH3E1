using apiwebFestivos.core.Repositorios;
using apiwebFestivos.core.servicios;
using apiwebFestivos.dominio;

namespace apiwebFestivos.aplicacion
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
            => await repositorio.ObtenerTodos();

        public async Task<Festivo?> ObtenerPorId(int id)
            => await repositorio.ObtenerPorId(id);

        public async Task<Festivo> Crear(Festivo festivo)
            => await repositorio.Crear(festivo);

        public async Task<bool> Actualizar(Festivo festivo)
            => await repositorio.Actualizar(festivo);

        public async Task<bool> Eliminar(int id)
            => await repositorio.Eliminar(id);
    }
}