using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stocky.Shared.Models;

namespace Stocky.WebApi.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.BarCode)
            .IsRequired();
        
        builder.HasIndex(p => p.BarCode)
            .IsUnique();
    }
}