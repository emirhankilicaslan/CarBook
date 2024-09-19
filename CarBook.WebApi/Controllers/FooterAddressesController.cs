using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FooterAddressesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FooterAddressesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> FooterAddressList()
    {
        var values = await _mediator.Send(new GetFooterAddressQuery());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
    {
        await _mediator.Send(command);
        return Ok("Alt adres bilgisi başarıyla eklendi !");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFooterAddress(int id)
    {
        var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
        return Ok(value);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveFooterAddress(int id)
    {
        await _mediator.Send(new RemoveFooterAddressCommand(id));
        return Ok("Alt adres bilgisi başarıyla silindi !");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
    {
        await _mediator.Send(command);
        return Ok("Alt adres bilgisi başarıyla güncellendi");
    }
}