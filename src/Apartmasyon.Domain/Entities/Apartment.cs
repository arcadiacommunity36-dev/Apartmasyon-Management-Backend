using Apartmasyon.Domain.Common;

namespace Apartmasyon.Domain.Entities;

public class Apartment : BaseEntity
{
    public string Number { get; set; } = string.Empty;
    public int Floor { get; set; }
    public string Type { get; set; } = "3+1";
    public bool IsOccupied { get; set; } = false;
    public string TenantName { get; set; } = string.Empty;

    public Guid BuildingId { get; set; }
    public Building Building { get; set; } = null!;

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}