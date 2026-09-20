using apiwebFestivos.core.Repositorios;
using apiwebFestivos.datos;
using apiwebFestivos.dominio;
using Microsoft.EntityFrameworkCore;

namespace apiwebFestivos.infraestructura.Repositorios
{
    public class FestivoRepositorio : IFestivoRepositorio
    {
        private readonly apiFestivoContext contexto;

        public FestivoRepositorio(apiFestivoContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await contexto.festivos.ToListAsync();
        }

        public async Task<Festivo?> ObtenerPorId(int id)
        {
            return await contexto.festivos
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Festivo> Crear(Festivo festivo)
        {
            contexto.festivos.Add(festivo);

            await contexto.SaveChangesAsync();

            return festivo;
        }

        public async Task<bool> Actualizar(Festivo festivo)
        {
            var existente = await contexto.festivos
                .FindAsync(festivo.Id);

            if (existente == null)
                return false;

            existente.IdPais = festivo.IdPais;
            existente.Nombre = festivo.Nombre;
            existente.Dia = festivo.Dia;
            existente.Mes = festivo.Mes;
            existente.DiasPascua = festivo.DiasPascua;
            existente.IdTipo = festivo.IdTipo;

            await contexto.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var festivo = await contexto.festivos
                .FindAsync(id);

            if (festivo == null)
                return false;

            contexto.festivos.Remove(festivo);

            await contexto.SaveChangesAsync();

            return true;
        }
    }
}