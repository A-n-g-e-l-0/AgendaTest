using AgendaTest.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AgendaTest.Context
{
    public class PersonasContext : DbContext
    {
        public PersonasContext(DbContextOptions<PersonasContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .HasKey(p => p.Id); // Set Id as the primary key

            modelBuilder.Entity<Persona>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd(); // Auto-generate Id on add
        }
    }
}
