using InvestmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Infrastructure.Data
{
    public class InvestmentDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        public InvestmentDbContext(DbContextOptions<InvestmentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações de entidades
        }
    }

}
