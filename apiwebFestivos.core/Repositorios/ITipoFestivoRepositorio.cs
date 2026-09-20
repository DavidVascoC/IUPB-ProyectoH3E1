using apiwebFestivos.dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace apiwebFestivos.core.Repositorios
{
    public interface ITipoFestivoRepositorio
    {
        Task<IEnumerable<TipoFestivo>> ObtenerTodos();

        Task<TipoFestivo?> ObtenerPorId(int id);

        Task<TipoFestivo> Crear(TipoFestivo tipoFestivo);

        Task<bool> Actualizar(TipoFestivo tipoFestivo);

        Task<bool> Eliminar(int id);
    }
}
