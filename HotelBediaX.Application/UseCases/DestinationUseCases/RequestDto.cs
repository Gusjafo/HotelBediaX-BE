using System.ComponentModel.DataAnnotations;
using HotelBediaX.Domain.Enums;

namespace HotelBediaX.Application.UseCases.DestinationUseCases
{
    public class CreateDto
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public required string CountryCode { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public DestinationType Type { get; set; }
    }

    public class UpdateDto : CreateDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}

