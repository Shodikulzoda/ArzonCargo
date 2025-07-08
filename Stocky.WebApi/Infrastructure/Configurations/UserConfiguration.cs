using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stocky.Shared.Models;

namespace Stocky.WebApi.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Name).HasMaxLength(100);
        builder.Property(u => u.Phone).HasMaxLength(20);
        builder.Property(u => u.Address).HasMaxLength(255);
        
        builder.HasIndex(u => u.Phone).IsUnique();
    }
}