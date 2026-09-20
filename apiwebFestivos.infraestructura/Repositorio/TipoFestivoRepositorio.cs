using apiwebFestivos.core.Repositorios;
using apiwebFestivos.datos;
using apiwebFestivos.dominio;
using Microsoft.EntityFrameworkCore;

namespace apiwebFestivos.infraestructura.Repositorios
{
    public class TipoFestivoRepositorio : ITipoFestivoRepositorio
    {
        private readonly apiFestivoContext contexto;

        public TipoFestivoRepositorio(apiFestivoContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IEnumerable<TipoFestivo>> ObtenerTodos()
        {
            return await contexto.tiposFestivos.ToListAsync();
        }

        public async Task<TipoFestivo?> ObtenerPorId(int id)
        {
            return await contexto.tiposFestivos
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TipoFestivo> Crear(TipoFestivo tipoFestivo)
        {
            contexto.tiposFestivos.Add(tipoFestivo);

            await contexto.SaveChangesAsync();

            return tipoFestivo;
        }

        public async Task<bool> Actualizar(TipoFestivo tipoFestivo)
        {
            var existente = await contexto.tiposFestivos
                .FindAsync(tipoFestivo.Id);

            if (existente == null)
                return false;

            existente.Tipo = tipoFestivo.Tipo;

            await contexto.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipoFestivo = await contexto.tiposFestivos
                .FindAsync(id);

            if (tipoFestivo == null)
                return false;

            contexto.tiposFestivos.Remove(tipoFestivo);

            await contexto.SaveChangesAsync();

            return true;
        }
    }
}