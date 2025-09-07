using HotelBediaX.Application.Interfaces;
using HotelBediaX.Application.UseCases.DestinationUseCases;
using Moq;

namespace HotelBediaX.Tests.UseCases.DestinationTest
{
    public class DeleteTests
    {
        [Fact]
        public async Task Should_Call_Repository_Delete()
        {
            // Arrange
            var mockRepo = new Mock<IDestinationRepository>();
            mockRepo.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask);
            var useCase = new DeleteUseCase(mockRepo.Object);

            // Act
            await useCase.ExecuteAsync(1);

            // Assert
            mockRepo.Verify(r => r.DeleteAsync(1), Times.Once);
        }
    }
}
