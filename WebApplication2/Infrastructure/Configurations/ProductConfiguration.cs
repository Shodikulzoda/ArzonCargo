using ArzonCargo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("char(36)");

        builder.Property(p => p.BarCode).HasMaxLength(1);
        builder.Property(p => p.Status).HasColumnType("int");
        builder.Property(p => p.CreatedAt).HasColumnType("datetime(6)");
    }
}
