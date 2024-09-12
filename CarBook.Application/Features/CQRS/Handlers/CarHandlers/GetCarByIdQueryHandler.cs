using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarByIdQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarByIdQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    } 
    
    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return new GetCarByIdQueryResult
        {
            BrandID = value.BrandID,
            BigImageUrl = value.BigImageUrl,
            CoverImageUrl = value.CoverImageUrl,
            Fuel = value.Fuel,
            CarID = value.CarID,
            Transmission = value.Transmission,
            Seats = value.Seats,
            Model = value.Model,
            Km = value.Km,
            Luggage = value.Luggage
        };
    }
}