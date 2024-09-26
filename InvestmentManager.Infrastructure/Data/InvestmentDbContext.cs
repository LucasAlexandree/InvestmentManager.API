using InvestmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Infrastructure.Data
{
    public class InvestmentDbContext : DbContext
    {
        public InvestmentDbContext(DbContextOptions<InvestmentDbContext> options) : base(options)
        {
        }

        // Define os DbSets para as entidades do domínio
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais para entidades
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Symbol).IsRequired().HasMaxLength(10);
                entity.Property(a => a.Type).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Quantity).IsRequired();
                entity.Property(t => t.PricePerUnit).IsRequired().HasColumnType("decimal(18,2)");
            });
        }
    }
}
