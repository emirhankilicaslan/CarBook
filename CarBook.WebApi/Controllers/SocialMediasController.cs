using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SocialMediasController : ControllerBase
{
    private readonly IMediator _mediator;

    public SocialMediasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> SocialMediaList()
    {
        var values = await _mediator.Send(new GetSocialMediaQuery());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok("Sosyal medya bilgisi başarıyla eklendi !");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSocialMedia(int id)
    {
        var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
        return Ok(value);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveSocialMedia(int id)
    {
        await _mediator.Send(new RemoveSocialMediaCommand(id));
        return Ok("Sosyal medya bilgisi başarıyla silindi !");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Ok("Sosyal medya bilgisi başarıyla güncellendi");
    }
}