using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReferenceClass.Models;
using ReferenceClass.Models.Enums;

namespace Stocky.WebApi.Infrastructure.Configurations;

public class AuthConfiguration : IEntityTypeConfiguration<AuthenticationData>
{
    public void Configure(EntityTypeBuilder<AuthenticationData> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Role)
            .HasDefaultValue(Role.User);
        
        builder.HasIndex(x=> x.UserName)
            .IsUnique();
    }
}