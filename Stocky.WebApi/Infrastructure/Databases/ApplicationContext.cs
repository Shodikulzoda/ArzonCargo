using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using Stocky.WebApi.Infrastructure.Configurations;

namespace Stocky.WebApi.Infrastructure.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<AuthenticationData> AuthenticationData { get; set; }
    public DbSet<Pocket> Pockets { get; set; }
    public DbSet<PocketItem> PocketItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}