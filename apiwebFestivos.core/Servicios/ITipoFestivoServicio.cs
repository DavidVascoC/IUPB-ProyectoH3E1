using apiwebFestivos.dominio;

namespace apiwebFestivos.core.servicios
{
    public interface ITipoFestivoServicio
    {
        Task<IEnumerable<TipoFestivo>> ObtenerTodos();

        Task<TipoFestivo?> ObtenerPorId(int id);

        Task<TipoFestivo> Crear(TipoFestivo tipoFestivo);

        Task<bool> Actualizar(TipoFestivo tipoFestivo);

        Task<bool> Eliminar(int id);
    }
}