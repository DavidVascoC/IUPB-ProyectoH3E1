using Microsoft.EntityFrameworkCore;
using apiwebFestivos.dominio;

namespace apiwebFestivos.datos
{
    public class apiFestivoContext : DbContext
    {
        public DbSet<Festivo> festivos { get; set; }
        public DbSet<Pais> paises { get; set; }
        public DbSet<TipoFestivo> tiposFestivos { get; set; }

        public apiFestivoContext(DbContextOptions<apiFestivoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder constructor)
        {
            // Tabla Pais
            constructor.Entity<Pais>(entidadPais =>
            {
                entidadPais.HasKey(p => p.Id);

                entidadPais.HasIndex(p => p.Nombre)
                           .IsUnique();
            });

            // Tabla TipoFestivo
            constructor.Entity<TipoFestivo>(entidadTipoFestivo =>
            {
                entidadTipoFestivo.HasKey(t => t.Id);
            });

            // Tabla Festivo
            constructor.Entity<Festivo>(entidadFestivo =>
            {
                entidadFestivo.HasKey(f => f.Id);

                // Relación Festivo -> Pais
                entidadFestivo.HasOne<Pais>()
                              .WithMany()
                              .HasForeignKey(f => f.IdPais)
                              .OnDelete(DeleteBehavior.Restrict);

                // Relación Festivo -> TipoFestivo
                entidadFestivo.HasOne<TipoFestivo>()
                              .WithMany()
                              .HasForeignKey(f => f.IdTipo)
                              .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}