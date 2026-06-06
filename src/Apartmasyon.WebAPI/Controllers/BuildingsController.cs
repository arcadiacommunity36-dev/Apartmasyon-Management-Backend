using Apartmasyon.Application.Features.Buildings.Commands.CreateBuilding;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Apartmasyon.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BuildingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBuildingCommand command)
    {
        var buildingId = await _mediator.Send(command);
        return Ok(buildingId);
    }
}