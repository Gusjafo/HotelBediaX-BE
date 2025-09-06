using HotelBediaX.Domain.Enums;

namespace HotelBediaX.Domain.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CountryCode { get; set; }
        public string? Description { get; set; }
        public DestinationType Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
