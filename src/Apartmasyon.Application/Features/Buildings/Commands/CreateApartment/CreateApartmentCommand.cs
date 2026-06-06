using Apartmasyon.Application.Common.Interfaces;
using Apartmasyon.Domain.Entities;
using MediatR;

namespace Apartmasyon.Application.Features.Apartments.Commands.CreateApartment;

public record CreateApartmentCommand(string Number, int Floor, string Type, bool IsOccupied, string TenantName, Guid BuildingId) : IRequest<Guid>;

public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, Guid>
{
    private readonly IApartmentDbContext _context;

    public CreateApartmentCommandHandler(IApartmentDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
    {
        var apartment = new Apartment
        {
            Number = request.Number,
            Floor = request.Floor,
            Type = request.Type,
            IsOccupied = request.IsOccupied,
            TenantName = request.TenantName,
            BuildingId = request.BuildingId
        };

        _context.Apartments.Add(apartment);
        await _context.SaveChangesAsync(cancellationToken);

        return apartment.Id;
    }
}