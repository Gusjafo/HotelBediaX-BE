using HotelBediaX.Application.Interfaces;
using System.Threading;

namespace HotelBediaX.Application.UseCases.DestinationUseCases;

public class UpdateUseCase(IDestinationRepository repository)
{
    private readonly IDestinationRepository _repository = repository;

    public async Task ExecuteAsync(UpdateDto dto, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(dto.Id, cancellationToken);
        if (existing is null)
            throw new InvalidOperationException($"Destination with ID {dto.Id} not found");

        existing.Name = dto.Name;
        existing.CountryCode = dto.CountryCode;
        existing.Description = dto.Description;
        existing.Type = dto.Type;
        existing.UpdatedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(existing, cancellationToken);
    }
}

