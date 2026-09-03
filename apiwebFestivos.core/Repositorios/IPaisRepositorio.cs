using System;
using System.Collections.Generic;
using System.Text;
using apiwebFestivos.dominio;
namespace apiwebFestivos.core.Repositorios
{
    public interface IPaisRepositorio
    {

        Task<IEnumerable<Pais>> ObtenerDatos();
        Task<Pais> Obtener(int Id);

        Task<IEnumerable<Pais>> Buscar(int IndiceDato, string Texto);

        Task<Pais> Agregar(Pais Seleccion);

        Task<Pais> Modificar(Pais Seleccion);

        Task<bool> Eliminar(int id);
    }
}
