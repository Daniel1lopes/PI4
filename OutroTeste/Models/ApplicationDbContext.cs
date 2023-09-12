using Microsoft.EntityFrameworkCore;

namespace OutroTeste.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CentroAtendimento> CentroAtendimentos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<UnidadeAtendimento> UnidadeAtendimentos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CentroAtendimento>().ToTable("CentroAtendimento", schema: "CACTB");
            modelBuilder.Entity<Especialidade>().ToTable("Especialidade", schema: "CACTB");

            base.OnModelCreating(modelBuilder);
        }
    }
}
