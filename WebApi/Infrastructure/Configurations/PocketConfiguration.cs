using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Models;

namespace WebApi.Infrastructure.Configurations;

public class PocketConfiguration: IEntityTypeConfiguration<PocketItem>
{
    public void Configure(EntityTypeBuilder<PocketItem> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.HasOne(x=>x.Order)
            .WithMany(x=>x.PocketItem)
            .HasForeignKey(x=>x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}