using Apartmasyon.Application.Common.Interfaces;
using Apartmasyon.Domain.Entities;
using MediatR;

namespace Apartmasyon.Application.Features.Buildings.Commands.CreateBuilding;

public record CreateBuildingCommand(string Name, string Address, int TotalFloors) : IRequest<Guid>;

public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, Guid>
{
    private readonly IApartmentDbContext _context;

    public CreateBuildingCommandHandler(IApartmentDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
    {
        var building = new Building
        {
            Name = request.Name,
            Address = request.Address,
            TotalFloors = request.TotalFloors
        };

        _context.Buildings.Add(building);
        await _context.SaveChangesAsync(cancellationToken);

        return building.Id;
    }
}