using HotelBediaX.Application.Interfaces;
using HotelBediaX.Domain.Entities;

namespace HotelBediaX.Application.UseCases.DestinationUseCases;

public class GetByIdUseCase(IDestinationRepository repository)
{
    private readonly IDestinationRepository _repository = repository;

    public async Task<Destination?> ExecuteAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
