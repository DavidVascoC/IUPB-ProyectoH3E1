using apiwebFestivos.core.Repositorios;
using apiwebFestivos.datos;
using apiwebFestivos.dominio;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        // Métodos añadidos para cumplir la interfaz IPaisRepositorio

        public Task<IEnumerable<Pais>> ObtenerDatos()
        {
            // delega al método existente
            return ObtenerTodos();
        }

        public async Task<Pais> Obtener(int Id)
        {
            // delega a ObtenerPorId; lanza si no existe para respetar la firma no nullable
            var pais = await ObtenerPorId(Id);
            if (pais == null)
                throw new KeyNotFoundException($"País con id {Id} no encontrado.");
            return pais;
        }

        public async Task<IEnumerable<Pais>> Buscar(int IndiceDato, string Texto)
        {
            // Implementación simple: buscar por nombre. Ajustar según la semántica real de IndiceDato.
            if (string.IsNullOrWhiteSpace(Texto))
                return await ObtenerTodos();

            return await contexto.paises
                .Where(p => EF.Functions.Like(p.Nombre, $"%{Texto}%"))
                .ToListAsync();
        }

        public Task<Pais> Agregar(Pais Seleccion)
        {
            // delega a Crear
            return Crear(Seleccion);
        }

        public async Task<Pais> Modificar(Pais Seleccion)
        {
            var ok = await Actualizar(Seleccion);
            if (!ok)
                throw new KeyNotFoundException($"País con id {Seleccion.Id} no encontrado.");
            return Seleccion;
        }
    }
}