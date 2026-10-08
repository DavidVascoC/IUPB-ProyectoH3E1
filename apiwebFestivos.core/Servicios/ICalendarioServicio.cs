using apiwebFestivos.core.Dtos;

namespace apiwebFestivos.core.servicios
{
    public interface ICalendarioServicio
    {
        Task<string> VerificarFecha(int idPais, int anio, int mes, int dia);

        Task<IEnumerable<FestivoFechaDto>> ListarFestivos(int idPais, int anio);
    }
}
