using HotelBediaX.Domain.Enums;

namespace HotelBediaX.Application.UseCases.DestinationUseCases
{
    public class CreateDto
    {
        public required string Name { get; set; }
        public required string CountryCode { get; set; }
        public string? Description { get; set; }
        public DestinationType Type { get; set; }
    }

    public class UpdateDto : CreateDto
    {
        public int Id { get; set; }
    }
}
