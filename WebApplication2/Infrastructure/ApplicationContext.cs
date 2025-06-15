using ArzonCargo.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Infrastructure.Configurations;

namespace WebApplication2.Infrastructure;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(UserConfiguration).Assembly;
        
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}
