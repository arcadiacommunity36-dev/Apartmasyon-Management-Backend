using Apartmasyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartmasyon.Persistence.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(i => i.Amount)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(i => i.Apartment)
            .WithMany(a => a.Invoices)
            .HasForeignKey(i => i.ApartmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}