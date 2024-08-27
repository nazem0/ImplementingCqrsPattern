using ImplementingCqrsPattern.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ImplementingCqrsPattern.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext() { }
    public AppDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Author> Authors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(bulder =>
        {
            bulder.ToTable(nameof(Author));
        });
        base.OnModelCreating(modelBuilder);
    }
}
