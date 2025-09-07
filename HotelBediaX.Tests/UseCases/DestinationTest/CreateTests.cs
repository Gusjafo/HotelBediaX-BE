using FluentAssertions;
using HotelBediaX.Application.Interfaces;
using HotelBediaX.Application.UseCases.DestinationUseCases;
using HotelBediaX.Domain.Enums;
using HotelBediaX.Domain.Entities;
using Moq;

namespace HotelBediaX.Tests.UseCases.DestinationTest
{
    public class CreateTests
    {
        [Fact]
        public async Task Should_Call_Repository_And_Return_Id()
        {
            // Arrange
            var mockRepo = new Mock<IDestinationRepository>();
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Destination>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var useCase = new CreateUseCase(mockRepo.Object);

            var command = new CreateDto
            {
                Name = "Mock City",
                CountryCode = "MC",
                Description = "Test",
                Type = DestinationType.City
            };

            // Act
            var id = await useCase.ExecuteAsync(command, CancellationToken.None);

            // Assert
            id.Should().Be(1);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Destination>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
