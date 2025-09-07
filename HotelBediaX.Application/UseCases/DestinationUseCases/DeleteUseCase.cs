using HotelBediaX.Application.Interfaces;
using System.Threading;

namespace HotelBediaX.Application.UseCases.DestinationUseCases;

public class DeleteUseCase(IDestinationRepository repository)
{
    private readonly IDestinationRepository _repository = repository;

    public async Task ExecuteAsync(int id, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(id, cancellationToken);
    }
}

