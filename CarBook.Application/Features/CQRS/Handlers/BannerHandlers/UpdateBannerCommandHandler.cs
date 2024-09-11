using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers;

public class UpdateBannerCommandHandler
{
    private readonly IRepository<Banner> _repository;

    public UpdateBannerCommandHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBannerCommand command)
    {
        var entity = await _repository.GetByIdAsync(command.BannerID);
        entity.Description = command.Description;
        entity.Title = command.Title;
        entity.VideoDescription = command.VideoDescription;
        entity.VideoUrl = command.VideoUrl;
        await _repository.UpdateAsync(entity);
    }
}