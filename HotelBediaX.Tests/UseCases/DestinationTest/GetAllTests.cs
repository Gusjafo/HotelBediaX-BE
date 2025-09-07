using FluentAssertions;
using HotelBediaX.Application.Interfaces;
using HotelBediaX.Application.UseCases.Common;
using HotelBediaX.Application.UseCases.DestinationUseCases;
using HotelBediaX.Domain.Entities;
using HotelBediaX.Domain.Enums;
using Moq;
using System.Collections.Generic;
using System.Threading;

namespace HotelBediaX.Tests.UseCases.DestinationTest
{
    public class GetAllTests
    {
        [Fact]
        public async Task Should_Call_Repository_And_Return_Pagination()
        {
            // Arrange
            var pagination = new Pagination<Destination>
            {
                Content = new List<Destination>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Sample",
                        CountryCode = "SS",
                        Type = DestinationType.City,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    }
                },
                TotalElements = 1,
                TotalPages = 1,
                Size = 10,
                Number = 1
            };

            var mockRepo = new Mock<IDestinationRepository>();
            mockRepo.Setup(r => r.GetAllAsync(1, 10, null, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(pagination);

            var useCase = new GetAllUseCase(mockRepo.Object);

            // Act
            var result = await useCase.ExecuteAsync(1, 10, null, CancellationToken.None);

            // Assert
            result.Should().Be(pagination);
            mockRepo.Verify(r => r.GetAllAsync(1, 10, null, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

