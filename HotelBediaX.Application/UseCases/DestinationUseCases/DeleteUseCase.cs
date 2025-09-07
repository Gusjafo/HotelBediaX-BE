using HotelBediaX.Application.Interfaces;
using System.Threading;

namespace HotelBediaX.Application.UseCases.DestinationUseCases;

public class DeleteUseCase(IDestinationRepository repository)
{
    private readonly IDestinationRepository _repository = repository;

        public async Task<bool> ExecuteAsync(int id, CancellationToken cancellationToken)
        {
            var destination = await _repository.GetByIdAsync(id, cancellationToken);
            if (destination is null)
                return false;

            await _repository.DeleteAsync(id, cancellationToken);
            return true;
        }
}

