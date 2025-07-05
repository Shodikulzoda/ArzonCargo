using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stocky.Shared.Models;

namespace Stocky.WebApi.Infrastructure.Configurations;

public class PocketConfiguration : IEntityTypeConfiguration<Pocket>
{
    public void Configure(EntityTypeBuilder<Pocket> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(o => o.User)
            .WithMany(u => u.Pockets)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}