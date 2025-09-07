using FluentAssertions;
using HotelBediaX.Application.Interfaces;
using HotelBediaX.Application.UseCases.DestinationUseCases;
using HotelBediaX.Domain.Entities;
using HotelBediaX.Domain.Enums;
using Moq;
using System.Threading;

namespace HotelBediaX.Tests.UseCases.DestinationTest
{
    public class UpdateTests
    {
        [Fact]
        public async Task Should_Update_Destination_And_Call_Repository()
        {
            // Arrange
            var existing = new Destination
            {
                Id = 1,
                Name = "Old",
                CountryCode = "OL",
                Description = "Old desc",
                Type = DestinationType.City,
                CreatedDate = DateTime.UtcNow
            };
            var mockRepo = new Mock<IDestinationRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(existing.Id, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(existing);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Destination>(), It.IsAny<CancellationToken>()))
                    .Returns(Task.CompletedTask);
            var useCase = new UpdateUseCase(mockRepo.Object);

            var dto = new UpdateDto
            {
                Id = 1,
                Name = "New",
                CountryCode = "NW",
                Description = "New desc",
                Type = DestinationType.Mountain
            };

            // Act
            await useCase.ExecuteAsync(dto, CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.GetByIdAsync(existing.Id, It.IsAny<CancellationToken>()), Times.Once);
            mockRepo.Verify(r => r.UpdateAsync(It.Is<Destination>(d =>
                d.Id == dto.Id &&
                d.Name == dto.Name &&
                d.CountryCode == dto.CountryCode &&
                d.Description == dto.Description &&
                d.Type == dto.Type &&
                d.UpdatedDate != default
            ), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
