using System;
using System.Collections.Generic;
using System.Text;
using apiwebFestivos.dominio;
namespace apiwebFestivos.core.Repositorios
{
    public interface IPaisRepositorio
    {
        Task<IEnumerable<Pais>> ObtenerTodos();
        Task<Pais?> ObtenerPorId(int id);
        Task<Pais> Crear(Pais pais);
        Task<bool> Actualizar(Pais pais);
        Task<bool> Eliminar(int id);
    }
}
