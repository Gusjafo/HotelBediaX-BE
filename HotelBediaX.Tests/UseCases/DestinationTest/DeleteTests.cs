using FluentAssertions;
using HotelBediaX.Application.Interfaces;
using HotelBediaX.Application.UseCases.DestinationUseCases;
using HotelBediaX.Domain.Entities;
using Moq;
using System.Threading;

namespace HotelBediaX.Tests.UseCases.DestinationTest
{
    public class DeleteTests
    {
        [Fact]
        public async Task Should_Call_Repository_Delete()
        {
            // Arrange
            var mockRepo = new Mock<IDestinationRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new Destination
                    {
                        Name = "Sample Destination",
                        CountryCode = "US"
                    });
            mockRepo.Setup(r => r.DeleteAsync(1, It.IsAny<CancellationToken>()))
                    .Returns(Task.CompletedTask);
            var useCase = new DeleteUseCase(mockRepo.Object);

            // Act
            var result = await useCase.ExecuteAsync(1, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
            mockRepo.Verify(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()), Times.Once);
            mockRepo.Verify(r => r.DeleteAsync(1, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Should_Return_False_When_Destination_Not_Found()
        {
            // Arrange
            var mockRepo = new Mock<IDestinationRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
                    .ReturnsAsync((Destination?)null);
            var useCase = new DeleteUseCase(mockRepo.Object);

            // Act
            var result = await useCase.ExecuteAsync(1, CancellationToken.None);

            // Assert
            result.Should().BeFalse();
            mockRepo.Verify(r => r.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
