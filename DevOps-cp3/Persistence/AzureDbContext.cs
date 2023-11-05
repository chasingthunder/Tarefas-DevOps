using DevOps_cp3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevOps_cp3.Persistence
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options) : base(options) {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lembrete> Lembretes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>()
                .ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
        }

    }
}
