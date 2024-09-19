using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> LocationList()
    {
        var values = await _mediator.Send(new GetLocationQuery());
        return Ok(values);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocation(int id)
    {
        var value = await _mediator.Send(new GetLocationByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Lokasyon bilgisi başarıyla eklendi !");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveLocation(int id)
    {
        await _mediator.Send(new RemoveLocationCommand(id));
        return Ok("Lokasyon bilgisi başarıyla silindi !");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Lokasyon bilgisi başarıyla güncellendi !");
    }
}