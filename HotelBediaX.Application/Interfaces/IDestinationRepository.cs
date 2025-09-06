using HotelBediaX.Domain.Entities;

namespace HotelBediaX.Application.Interfaces
{
    public interface IDestinationRepository
    {
        Task<int> AddAsync(Destination destination);
        Task<Destination?> GetByIdAsync(int id);
        Task<List<Destination>> GetAllAsync(string? filter = null);
        Task UpdateAsync(Destination destination);
        Task DeleteAsync(int id);
    }
}
