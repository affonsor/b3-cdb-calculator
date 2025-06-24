using B3.Cdb.Calculator.Application.Services;
using B3.Cdb.Calculator.Domain.Dto.Request;
using B3.Cdb.Calculator.Domain.Resource;
using Microsoft.Extensions.Logging;
using Moq;

namespace B3.Cdb.Calculator.Tests.Service
{
    public class CdbInvestmentServiceTests
    {
        private readonly Mock<ILogger<CdbInvestmentService>> _mockLogger;
        private readonly CdbInvestmentService _service;

        public CdbInvestmentServiceTests()
        {
            _mockLogger = new Mock<ILogger<CdbInvestmentService>>();
            _service = new CdbInvestmentService(_mockLogger.Object);
        }

        [Fact]
        public void CalculateCdbInvestment_ShouldReturnBadRequest_WhenInitialValueIsZeroOrNegative()
        {
            // Arrange
            var dto = new CdbInvestmentRequestDto { InitialValue = 0, Months = 12 };

            // Act & Assert
            var response = _service.CalculateCdbInvestment(dto);

            // Assert
            Assert.Equal(400, response.StatusCode);
            Assert.Contains(Messages.InvalidInitialValue, response.Message);
        }

        [Fact]
        public void CalculateCdbInvestment_ShouldReturnBadRequest_WhenMonthsIsLessThanOne()
        {
            // Arrange
            var dto = new CdbInvestmentRequestDto { InitialValue = 1000m, Months = 0 };

            // Act
            var response = _service.CalculateCdbInvestment(dto);

            // Assert
            Assert.Equal(400, response.StatusCode);
            Assert.Contains(Messages.InvalidPeriod, response.Message);
        }

        [Fact]
        public void CalculateCdbInvestment_ShouldReturnSuccess_WhenInputIsValid()
        {
            // Arrange
            var dto = new CdbInvestmentRequestDto { InitialValue = 1000m, Months = 12 };

            // Act
            var response = _service.CalculateCdbInvestment(dto);

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(response.Data);
            Assert.Equal(1123.08m, response.Data.GrossReturn);
            Assert.Equal(1098.46m, response.Data.NetReturn);
        }
    }
}
