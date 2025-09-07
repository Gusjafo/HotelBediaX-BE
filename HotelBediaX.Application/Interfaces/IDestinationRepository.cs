using HotelBediaX.Application.UseCases.Common;
using HotelBediaX.Domain.Entities;

namespace HotelBediaX.Application.Interfaces
{
    public interface IDestinationRepository
    {
        Task<int> AddAsync(Destination destination);
        Task<Destination?> GetByIdAsync(int id);
        Task<Pagination<Destination>> GetAllAsync(int pageNumber, int pageSize, string? filter);
        Task UpdateAsync(Destination destination);
        Task DeleteAsync(int id);
    }
}
