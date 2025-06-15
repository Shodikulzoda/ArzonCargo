using ArzonCargo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("orderitems");

        builder.HasKey(oi => oi.Id);
        builder.Property(oi => oi.Id).HasColumnType("char(36)");

        builder.Property(oi => oi.Weight).HasColumnType("double");
        builder.Property(oi => oi.CreatedAt).HasColumnType("datetime(6)");

        builder.Property(oi => oi.ProductId).HasColumnType("char(36)");
        builder.Property(oi => oi.OrderId).HasColumnType("char(36)");

        builder.HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId);

        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);
    }
}
