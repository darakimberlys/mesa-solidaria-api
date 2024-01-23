using MesaSolidariaApi.Core.Models;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Substitua "sua_string_de_conexao_mysql" pelos detalhes da sua conexão MySQL
        //optionsBuilder.UseMySql("sua_string_de_conexao_mysql");
    }
}


