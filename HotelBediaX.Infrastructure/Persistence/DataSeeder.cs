using HotelBediaX.Domain.Entities;
using HotelBediaX.Domain.Enums;

namespace HotelBediaX.Infrastructure.Persistence
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Destinations.Any())
                return;

            var now = DateTime.UtcNow;

            var destinations = new List<Destination>
        {
            new() { Name = "Barcelona", CountryCode = "ES", Description = "Ciudad costera y capital de Cataluña", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Madrid", CountryCode = "ES", Description = "Capital de España", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Paris", CountryCode = "FR", Description = "Ciudad de la Luz", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Nice", CountryCode = "FR", Description = "Riviera francesa", Type = DestinationType.Beach, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Berlin", CountryCode = "DE", Description = "Capital alemana moderna e histórica", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Munich", CountryCode = "DE", Description = "Ciudad bávara, famosa por el Oktoberfest", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Rome", CountryCode = "IT", Description = "La ciudad eterna", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Venice", CountryCode = "IT", Description = "Ciudad de los canales y góndolas", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Milan", CountryCode = "IT", Description = "Capital de la moda y el diseño", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Athens", CountryCode = "GR", Description = "Cuna de la democracia", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Santorini", CountryCode = "GR", Description = "Isla volcánica con casas blancas", Type = DestinationType.Beach, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Crete", CountryCode = "GR", Description = "Isla más grande de Grecia", Type = DestinationType.Beach, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Lisbon", CountryCode = "PT", Description = "Capital portuguesa en la costa atlántica", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Porto", CountryCode = "PT", Description = "Ciudad del vino de Oporto", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "New York", CountryCode = "US", Description = "La gran manzana", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Los Angeles", CountryCode = "US", Description = "Hollywood y playas del Pacífico", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Miami", CountryCode = "US", Description = "Playas y vida nocturna", Type = DestinationType.Beach, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Cancún", CountryCode = "MX", Description = "Destino caribeño en la Riviera Maya", Type = DestinationType.Beach, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Mexico City", CountryCode = "MX", Description = "Capital de México", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
            new() { Name = "Tokyo", CountryCode = "JP", Description = "Megaciudad futurista", Type = DestinationType.City, CreatedDate = now, UpdatedDate = now },
        };

            context.Destinations.AddRange(destinations);
            context.SaveChanges();
        }
    }
}
