using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Infrastructure.Repositories.Data;

public partial class EficazesDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    public EficazesDbContext()
    {
    }

    public EficazesDbContext(DbContextOptions<EficazesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
        .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Cliente>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Endereco>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Endereco>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
