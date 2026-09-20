using apiwebFestivos.core.Repositorios;
using apiwebFestivos.datos;
using apiwebFestivos.dominio;
using Microsoft.EntityFrameworkCore;

namespace apiwebFestivos.infraestructura.Repositorios
{
    public class PaisRepositorio : IPaisRepositorio
    {
        private readonly apiFestivoContext contexto;

        public PaisRepositorio(apiFestivoContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IEnumerable<Pais>> ObtenerTodos()
        {
            return await contexto.paises.ToListAsync();
        }

        public async Task<Pais?> ObtenerPorId(int id)
        {
            return await contexto.paises
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pais> Crear(Pais pais)
        {
            contexto.paises.Add(pais);

            await contexto.SaveChangesAsync();

            return pais;
        }

        public async Task<bool> Actualizar(Pais pais)
        {
            var existente = await contexto.paises
                .FindAsync(pais.Id);

            if (existente == null)
                return false;

            existente.Nombre = pais.Nombre;

            await contexto.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var pais = await contexto.paises.FindAsync(id);

            if (pais == null)
                return false;

            contexto.paises.Remove(pais);

            await contexto.SaveChangesAsync();

            return true;
        }
    }
}