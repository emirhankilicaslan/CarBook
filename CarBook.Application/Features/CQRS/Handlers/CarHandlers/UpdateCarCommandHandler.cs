using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public UpdateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarCommand command)
    {
        var entity = await _repository.GetByIdAsync(command.CarID);
        entity.Fuel = command.Fuel;
        entity.BrandID = command.BrandID;
        entity.Transmission = command.Transmission;
        entity.Luggage = command.Luggage;
        entity.Km = command.Km;
        entity.Seats = command.Seats;
        entity.Model = command.Model;
        entity.CoverImageUrl = command.CoverImageUrl;
        entity.BigImageUrl = command.BigImageUrl;
        await _repository.UpdateAsync(entity);
    }
}