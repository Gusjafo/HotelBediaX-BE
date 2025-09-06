using HotelBediaX.Application.UseCases.DestinationUseCases;

namespace HotelBediaX.WebApi.DI
{
    public static class UseCaseServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<CreateUseCase>();
            services.AddScoped<GetByIdUseCase>();
            services.AddScoped<GetAllUseCase>();
            services.AddScoped<UpdateUseCase>();
            services.AddScoped<DeleteUseCase>();

            return services;
        }
    }
}
