using MesaSolidariaApi.Core.Models;
using MesaSolidariaApi.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MesaSolidariaApi.Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DeliveriesConfiguration());
        modelBuilder.ApplyConfiguration(new PackagesConfiguration());
        modelBuilder.ApplyConfiguration(new ProductsConfiguration());
    }
}
