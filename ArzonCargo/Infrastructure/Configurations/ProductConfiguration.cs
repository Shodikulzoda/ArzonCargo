using ArzonCargo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArzonCargo.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .HasColumnType("char(50)");

        builder.Property(x => x.BarCode)
            .HasColumnType("char(50)");

        builder.Property(p => p.BarCode)
            .IsRequired();

        builder.Property(p => p.Status)
            .HasColumnType("int");

        builder.Property(p => p.CreatedAt)
            .IsRequired();
    }
}