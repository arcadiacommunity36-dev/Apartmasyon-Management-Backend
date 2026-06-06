using Apartmasyon.Application.Common.Interfaces;
using Apartmasyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Apartmasyon.Persistence.Contexts;

public class ApartmentDbContext : DbContext, IApartmentDbContext
{
    public ApartmentDbContext(DbContextOptions<ApartmentDbContext> options) : base(options)
    {
    }

    public DbSet<Building> Buildings { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}