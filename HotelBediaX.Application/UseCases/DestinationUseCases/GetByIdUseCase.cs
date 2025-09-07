using HotelBediaX.Application.Interfaces;
using HotelBediaX.Domain.Entities;
using System.Threading;

namespace HotelBediaX.Application.UseCases.DestinationUseCases;

public class GetByIdUseCase(IDestinationRepository repository)
{
    private readonly IDestinationRepository _repository = repository;

    public async Task<Destination?> ExecuteAsync(int id, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }
}

