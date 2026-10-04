using apiwebFestivos.core.Repositorios;
using apiwebFestivos.core.servicios;
using apiwebFestivos.dominio;

namespace apiwebFestivos.aplicacion
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio repositorio;

        public PaisServicio(IPaisRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Pais>> ObtenerTodos()
            => await repositorio.ObtenerTodos();

        public async Task<Pais?> ObtenerPorId(int id)
            => await repositorio.ObtenerPorId(id);

        public async Task<Pais> Crear(Pais pais)
            => await repositorio.Crear(pais);

        public async Task<bool> Actualizar(Pais pais)
            => await repositorio.Actualizar(pais);

        public async Task<bool> Eliminar(int id)
            => await repositorio.Eliminar(id);
    }
}