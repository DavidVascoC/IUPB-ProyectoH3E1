using apiwebFestivos.dominio;

namespace apiwebFestivos.core.Servicios
{
    public interface IFestivoServicio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();

        Task<Festivo?> ObtenerPorId(int id);

        Task<Festivo> Crear(Festivo festivo);

        Task<bool> Actualizar(Festivo festivo);

        Task<bool> Eliminar(int id);
    }
}