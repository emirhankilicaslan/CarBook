using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers;

public class UpdateAboutCommandHandler
{
    private readonly IRepository<About> _repository;

    public UpdateAboutCommandHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        var entity = await _repository.GetByIdAsync(command.AboutID);
        entity.Description = command.Description;
        entity.Title = command.Title;
        entity.ImageUrl = command.ImageUrl;
        await _repository.UpdateAsync(entity);
    }
}