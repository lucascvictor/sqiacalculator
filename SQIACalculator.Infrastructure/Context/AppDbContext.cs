using Microsoft.EntityFrameworkCore;
using SQIACalculator.Domain.Entities;
using SQIACalculator.Infrastructure.Seeds;

namespace SQIACalculator.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Cotacao> Cotacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cotacao>().ToTable("Cotacao");
            modelBuilder.ApplyConfiguration(new CotacaoSeed());
        }
    }
}
