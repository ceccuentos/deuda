using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class DeudaContext : DbContext

    {
        public DeudaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deuda>().HasNoKey();
            modelBuilder.Entity<Deuda>().Property(p => p.MontoCancelado).HasColumnType("decimal(22,8)");
            modelBuilder.Entity<Deuda>().Property(p => p.MontoTotal).HasColumnType("decimal(22,8)");
        }

        public DbSet<Deuda> DeudaAutoventa { get; set; }
    }
}

