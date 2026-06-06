using Apartmasyon.Domain.Common;

namespace Apartmasyon.Domain.Entities;

public class Invoice : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; } = false;
    public DateTime? PaymentDate { get; set; }

    public Guid ApartmentId { get; set; }
    public Apartment Apartment { get; set; } = null!;
}