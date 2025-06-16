using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArzonCargo.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<Models.User>
{
    public void Configure(EntityTypeBuilder<Models.User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("char(36)");

        builder.Property(u => u.Name).HasMaxLength(100);
        builder.Property(u => u.Phone).HasMaxLength(20);
        builder.Property(u => u.Address).HasMaxLength(255);
        builder.Property(u => u.Role).HasMaxLength(50);

        builder.Property(u => u.CreatedAt).HasColumnType("datetime");
    }
}
