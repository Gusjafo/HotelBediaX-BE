using HotelBediaX.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBediaX.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Destination> Destinations => Set<Destination>();
    }
}
