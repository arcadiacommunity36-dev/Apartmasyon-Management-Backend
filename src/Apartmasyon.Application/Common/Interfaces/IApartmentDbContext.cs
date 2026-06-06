using Apartmasyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apartmasyon.Application.Common.Interfaces;

public interface IApartmentDbContext
{
    DbSet<Building> Buildings { get; set; }
    DbSet<Apartment> Apartments { get; set; }
    DbSet<Invoice> Invoices { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}