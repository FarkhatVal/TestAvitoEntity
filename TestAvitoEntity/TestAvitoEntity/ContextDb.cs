using Microsoft.EntityFrameworkCore;
using TestAvitoEntity.models;

namespace TestAvitoEntity;

public class ContextDb : DbContext
{
    public ContextDb()
    {
        Database.EnsureCreated();
    }

    public DbSet<Car> Cars { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EntityDemo;Username=postgres;Password=admin");
    }
}