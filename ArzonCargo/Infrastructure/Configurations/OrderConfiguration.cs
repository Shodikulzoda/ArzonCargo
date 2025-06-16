using ArzonCargo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArzonCargo.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).HasColumnType("char(36)");

        builder.Property(o => o.BarCode).HasColumnType("longtext");
        builder.Property(o => o.TotalAmount).HasColumnType("double");
        builder.Property(o => o.TotalWeight).HasColumnType("double");
        builder.Property(o => o.Status).HasColumnType("int");
        builder.Property(o => o.CreatedAt).HasColumnType("datetime(6)");

        builder.Property(o => o.UserId).HasColumnType("char(36)");

        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}