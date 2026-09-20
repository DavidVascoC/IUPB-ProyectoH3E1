using apiwebFestivos.dominio;

namespace apiwebFestivos.core.servicios
{
    public interface IPaisServicio
    {
        Task<IEnumerable<Pais>> ObtenerTodos();

        Task<Pais?> ObtenerPorId(int id);

        Task<Pais> Crear(Pais pais);

        Task<bool> Actualizar(Pais pais);

        Task<bool> Eliminar(int id);
    }
}
