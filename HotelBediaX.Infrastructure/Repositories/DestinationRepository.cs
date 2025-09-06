using HotelBediaX.Application.Interfaces;
using HotelBediaX.Domain.Entities;
using HotelBediaX.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelBediaX.Infrastructure.Repositories
{
    public class DestinationRepository(AppDbContext context) : IDestinationRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<int> AddAsync(Destination destination)
        {
            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();
            return destination.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Destinations.FindAsync(id);
            if (entity is not null)
            {
                _context.Destinations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Destination>> GetAllAsync(string? filter = null)
        {
            var query = _context.Destinations.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(d =>
                    d.Name.Contains(filter) || d.CountryCode.Contains(filter));
            }

            return await query.ToListAsync();
        }

        public async Task<Destination?> GetByIdAsync(int id)
        {
            return await _context.Destinations.FindAsync(id);
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
            await _context.SaveChangesAsync();
        }
    }
}
