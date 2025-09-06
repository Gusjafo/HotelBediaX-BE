using HotelBediaX.Application.Interfaces;
using HotelBediaX.Infrastructure.Persistence;
using HotelBediaX.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelBediaX.WebApi.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration config)
    {
        // Repositorio
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        // Repositorio
        services.AddScoped<IDestinationRepository, DestinationRepository>();

        return services;
    }
}
