using HotelBediaX.Application.Interfaces;
using HotelBediaX.Domain.Entities;

namespace HotelBediaX.Application.UseCases.DestinationUseCases;

public class GetAllUseCase(IDestinationRepository repository)
{
    private readonly IDestinationRepository _repository = repository;

    public async Task<List<Destination>> ExecuteAsync(string? filter = null)
    {
        return await _repository.GetAllAsync(filter);
    }
}
