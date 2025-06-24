using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReferenceClass.Models;

namespace WebApi.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.BarCode)
            .IsRequired();
        
        builder.HasIndex(p => p.BarCode)
            .IsUnique();

        builder.Property(p => p.CreatedAt)
            .IsRequired();
    }
}