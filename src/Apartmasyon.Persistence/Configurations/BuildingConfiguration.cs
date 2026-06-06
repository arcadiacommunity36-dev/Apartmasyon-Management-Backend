using Apartmasyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartmasyon.Persistence.Configurations;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.Address)
            .HasMaxLength(250);
    }
}