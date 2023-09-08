using Duvido.GestãoDeGame.WEB_API.Data.Map;
using Duvido.GestãoDeGame.WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Duvido.GestãoDeGame.WEB_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            ChangeTracker.LazyLoadingEnabled = true;

        }

        public DbSet<ItensDaListaViewModel> ItensDaLista { get; set; }
        public DbSet<ListaViewModel> Lista { get; set; }
        public DbSet<UsuarioViewModel> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListaViewModel>()
                .HasMany(l => l.ItensDaLista)
                .WithOne()
                .HasForeignKey(i => i.IDDaLista);

            modelBuilder.ApplyConfiguration(new ItensDaListaMap());
            modelBuilder.ApplyConfiguration(new ListaMap());
            base.OnModelCreating(modelBuilder);
        }


    }
}
