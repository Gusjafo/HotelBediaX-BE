using HotelBediaX.Application.UseCases.Common;
using HotelBediaX.Domain.Entities;
using System.Threading;

namespace HotelBediaX.Application.Interfaces;

public interface IDestinationRepository
{
    Task<int> AddAsync(Destination destination, CancellationToken cancellationToken);
    Task<Destination?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Pagination<Destination>> GetAllAsync(int pageNumber, int pageSize, string? filter, CancellationToken cancellationToken);
    Task UpdateAsync(Destination destination, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}

