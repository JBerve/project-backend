using Microsoft.EntityFrameworkCore;
using Continuum.Core.Entities;

namespace Continuum.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        // Configura el modelo aquí si es necesario
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración del modelo
        }
    }
}