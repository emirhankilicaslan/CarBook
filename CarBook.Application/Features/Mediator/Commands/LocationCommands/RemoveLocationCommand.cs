using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands;

public class RemoveLocationCommand : IRequest
{
    public int Id { get; set; }

    public RemoveLocationCommand(int ıd)
    {
        Id = ıd;
    }
}