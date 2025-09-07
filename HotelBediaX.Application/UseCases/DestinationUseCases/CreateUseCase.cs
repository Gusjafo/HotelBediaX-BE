using HotelBediaX.Application.Interfaces;
using HotelBediaX.Domain.Entities;
using System.Threading;

namespace HotelBediaX.Application.UseCases.DestinationUseCases;

public class CreateUseCase(IDestinationRepository repository)
{
    private readonly IDestinationRepository _repository = repository;

    public async Task<int> ExecuteAsync(CreateDto dto, CancellationToken cancellationToken)
    {
        var destination = new Destination
        {
            Name = dto.Name,
            CountryCode = dto.CountryCode,
            Description = dto.Description,
            Type = dto.Type,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        return await _repository.AddAsync(destination, cancellationToken);
    }
}

