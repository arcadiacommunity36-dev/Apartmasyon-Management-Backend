using Apartmasyon.Domain.Common;

namespace Apartmasyon.Domain.Entities;

public class Building : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int TotalFloors { get; set; }

    public ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
}