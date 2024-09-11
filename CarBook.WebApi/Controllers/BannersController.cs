using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BannersController : ControllerBase
{
    private readonly CreateBannerCommandHandler _createBannerCommandHandler;
    private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
    private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
    private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
    private readonly GetBannerQueryHandler _getBannerQueryHandler;

    public BannersController(CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler)
    {
        _createBannerCommandHandler = createBannerCommandHandler;
        _updateBannerCommandHandler = updateBannerCommandHandler;
        _removeBannerCommandHandler = removeBannerCommandHandler;
        _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        _getBannerQueryHandler = getBannerQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> BannerList()
    {
        var values = await _getBannerQueryHandler.Handle();
        return Ok(values);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBanner(int id)
    {
        var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
        return Ok(value);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
    {
        await _createBannerCommandHandler.Handle(command);
        return Ok("Banner başarıyla eklendi !");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
    {
        await _updateBannerCommandHandler.Handle(command);
        return Ok("Banner başarıyla güncellendi !");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBanner(int id)
    {
        await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
        return Ok("Banner başarıyla silindi !");
    }
}