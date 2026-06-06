using Apartmasyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartmasyon.Persistence.Configurations;

public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Number)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(a => a.TenantName)
            .HasMaxLength(100);

        builder.HasOne(a => a.Building)
            .WithMany(b => b.Apartments)
            .HasForeignKey(a => a.BuildingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}