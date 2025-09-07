using FluentAssertions;
using HotelBediaX.Application.Interfaces;
using HotelBediaX.Application.UseCases.DestinationUseCases;
using HotelBediaX.Domain.Entities;
using HotelBediaX.Domain.Enums;
using Moq;
using System.Threading;

namespace HotelBediaX.Tests.UseCases.DestinationTest
{
    public class GetByIdTests
    {
        [Fact]
        public async Task Should_Call_Repository_And_Return_Destination()
        {
            // Arrange
            var expected = new Destination
            {
                Id = 1,
                Name = "Test",
                CountryCode = "TT",
                Description = "Desc",
                Type = DestinationType.Beach
            };
            var mockRepo = new Mock<IDestinationRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(expected);
            var useCase = new GetByIdUseCase(mockRepo.Object);

            // Act
            var result = await useCase.ExecuteAsync(1, CancellationToken.None);

            // Assert
            result.Should().Be(expected);
            mockRepo.Verify(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
