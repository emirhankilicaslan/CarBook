using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers;

public class CreateAboutCommandHandler
{
    private readonly IRepository<About> _repository;

    public CreateAboutCommandHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateAboutCommand command)
    {
        await _repository.CreateAsync(new About
        {
            Description = command.Description,
            Title = command.Title,
            ImageUrl = command.ImageUrl
        });
    }
}