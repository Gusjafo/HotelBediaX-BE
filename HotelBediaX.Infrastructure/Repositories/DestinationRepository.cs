using HotelBediaX.Application.Interfaces;
using HotelBediaX.Application.UseCases.Common;
using HotelBediaX.Domain.Entities;
using HotelBediaX.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace HotelBediaX.Infrastructure.Repositories;

public class DestinationRepository(AppDbContext context) : IDestinationRepository
{
    private readonly AppDbContext _context = context;

    public async Task<int> AddAsync(Destination destination, CancellationToken cancellationToken)
    {
        _context.Destinations.Add(destination);
        await _context.SaveChangesAsync(cancellationToken);
        return destination.Id;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _context.Destinations.FindAsync(new object?[] { id }, cancellationToken);
        if (entity is not null)
        {
            _context.Destinations.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<Pagination<Destination>> GetAllAsync(
        int pageNumber = 1,
        int pageSize = 10,
        string? filter = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Destinations.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter))
        {
            var normalizedFilter = filter.Trim().ToLower();

            query = query.Where(d =>
                d.Name.ToLower().Contains(normalizedFilter) ||
                d.CountryCode.ToLower().Contains(normalizedFilter) ||
                (d.Description != null && d.Description.ToLower().Contains(normalizedFilter)) ||
                d.Type.ToString().ToLower().Contains(normalizedFilter));
        }

        var totalElements = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(d => d.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new Pagination<Destination>
        {
            Content = items,
            TotalElements = totalElements,
            TotalPages = (int)Math.Ceiling(totalElements / (double)pageSize),
            Size = pageSize,
            Number = pageNumber
        };
    }


    public async Task<Destination?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Destinations.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task UpdateAsync(Destination destination, CancellationToken cancellationToken)
    {
        _context.Destinations.Update(destination);
        await _context.SaveChangesAsync(cancellationToken);
    }
}

