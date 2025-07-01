using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReferenceClass.Models;

namespace Stocky.WebApi.Infrastructure.Configurations;

public class AuthConfiguration : IEntityTypeConfiguration<AuthenticationData>
{
    public void Configure(EntityTypeBuilder<AuthenticationData> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
}