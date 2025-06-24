using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReferenceClass.Models;

namespace WebApi.Infrastructure.Configurations;

public class PocketItemConfiguration : IEntityTypeConfiguration<PocketItem>
{
    public void Configure(EntityTypeBuilder<PocketItem> builder)
    {
        builder.HasOne(oi => oi.Product)
            .WithMany(p => p.PocketItems)
            .HasForeignKey(oi => oi.ProductId);

        builder.HasOne(oi => oi.Pocket)
            .WithMany(o => o.PocketItems)
            .HasForeignKey(oi => oi.PocketId);
    }
}