using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class UpdateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public UpdateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateContactCommand command)
    {
        var entity = await _repository.GetByIdAsync(command.ContactID);
        entity.Name = command.Name;
        entity.Email = command.Email;
        entity.Subject = command.Subject;
        entity.Message = command.Message;
        entity.SendDate = command.SendDate;
        await _repository.UpdateAsync(entity);
    }
}