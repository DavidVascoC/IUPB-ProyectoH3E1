using apiwebFestivos.dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace apiwebFestivos.core.Repositorios
{
    public interface IFestivoRepositorio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();

        Task<Festivo?> ObtenerPorId(int id);

        Task<Festivo> Crear(Festivo festivo);

        Task<bool> Actualizar(Festivo festivo);

        Task<bool> Eliminar(int id);
    }
}
