using HotelBediaX.Application.Interfaces;
using HotelBediaX.Application.UseCases.Common;
using HotelBediaX.Domain.Entities;
using System.Threading;

namespace HotelBediaX.Application.UseCases.DestinationUseCases;

public class GetAllUseCase(IDestinationRepository repository)
{
    private readonly IDestinationRepository _repository = repository;

    public async Task<Pagination<Destination>> ExecuteAsync(
        int pageNumber = 1,
        int pageSize = 10,
        string? filter = null,
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(pageNumber, pageSize, filter, cancellationToken);
    }
}

