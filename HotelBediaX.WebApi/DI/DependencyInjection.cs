using HotelBediaX.Application.Interfaces;
using HotelBediaX.Infrastructure.Persistence;
using HotelBediaX.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelBediaX.WebApi.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration _)
    {
        // Database
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("HotelBediaXDb"));

        // Repositorio
        services.AddScoped<IDestinationRepository, DestinationRepository>();

        return services;
    }
}
