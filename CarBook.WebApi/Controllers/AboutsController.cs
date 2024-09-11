using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AboutsController : ControllerBase
{
    private readonly CreateAboutCommandHandler _createAboutCommandHandler;
    private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
    private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
    private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
    private readonly GetAboutQueryHandler _getAboutQueryHandler;

    public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, 
        UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler, 
        GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler)
    {
        _createAboutCommandHandler = createAboutCommandHandler;
        _updateAboutCommandHandler = updateAboutCommandHandler;
        _removeAboutCommandHandler = removeAboutCommandHandler;
        _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
        _getAboutQueryHandler = getAboutQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
        var values = await _getAboutQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAbout(int id)
    {
        var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
    {
        await _createAboutCommandHandler.Handle(command);
        return Ok("Hakkımda bilgisi başarıyla eklendi !");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
    {
        await _updateAboutCommandHandler.Handle(command);
        return Ok("Hakkımda bilgisi başarıyla güncellendi !");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAbout(int id)
    {
        await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
        return Ok("Hakkımda bilgisi başarıyla silindi !");
    }
}