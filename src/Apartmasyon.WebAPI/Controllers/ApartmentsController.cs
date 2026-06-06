using Apartmasyon.Application.Features.Apartments.Commands.CreateApartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Apartmasyon.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApartmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApartmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateApartmentCommand command)
    {
        var apartmentId = await _mediator.Send(command);
        return Ok(apartmentId);
    }
}