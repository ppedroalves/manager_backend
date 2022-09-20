
using Manager.Data.Mappings;
using Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data
{
    public class Context : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Oportunidade> Oportunidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Manager;User ID=sa;Password=1q2w3e4r@#$");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new OportunidadeMap());
        }

    }
}
