using Microsoft.EntityFrameworkCore;
using Carwash.Domain.Entities;
using Carwash.Domain.Data;

namespace Carwash.Infrastructure.EFCore;

/// <summary>
/// Контекст базы данных для управления сущностями Carwash
/// </summary>
/// <param name="options">Опции контекста базы данных</param>
public class CarwashDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Конфигурация сущности Car
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(c => c.Client).WithMany(c => c.Cars);
            entity.HasData(DataSeed.Cars);
        });
        // Конфигурация сущности Client
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasMany(c => c.Cars).WithOne(c => c.Client);
            entity.HasData(DataSeed.Clients);
        });
        // Конфигурация сущности Order
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Ignore(o => o.EndTime);
            entity.HasKey(e => e.Id);
            entity.HasOne(o => o.Car);
            entity.HasOne(o => o.Client);
            entity.HasOne(o => o.Service);
            entity.HasData(DataSeed.Orders);
        });
        // Конфигурация сущности Service
        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasData(DataSeed.Services);
        });
    }
}
