using B3.Cdb.Calculator.Domain.Entitie;
using B3.Cdb.Calculator.Domain.Resource;

namespace B3.Cdb.Calculator.Tests.Domain
{
    public class CdbInvestmentTests
    {
        [Fact]
        public void Constructor_ShouldSetInitialValue_WhenValidValueProvided()
        {
            // Arrange
            decimal initialValue = 1000m;

            // Act
            var investment = new CdbInvestment(initialValue);

            // Assert
            Assert.Equal(initialValue, investment.InitialValue);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenInitialValueIsInvalid()
        {
            // Arrange
            decimal invalidValue = Constants.MinimalInitialValue;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new CdbInvestment(invalidValue));
        }

        [Fact]
        public void Calculate_ShouldCalculateCorrectGrossAndNetReturn_ForValidMonths()
        {
            // Arrange
            var investment = new CdbInvestment(1000m);
            int months = 12;

            // Act
            investment.Calculate(months);

            // Assert
            Assert.Equal(1123.08m, investment.GrossReturn);
            Assert.Equal(1098.46m, investment.NetReturn);
        }

        [Fact]
        public void Calculate_ShouldThrowArgumentException_WhenMonthsAreInvalid()
        {
            // Arrange
            var investment = new CdbInvestment(1000m);
            int invalidMonths = Constants.MinimalPeriod;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => investment.Calculate(invalidMonths));
        }

        [Theory]
        [InlineData(6, 0.225)]
        [InlineData(12, 0.20)]
        [InlineData(24, 0.175)]
        [InlineData(36, 0.15)]
        public void GetTaxRate_ShouldReturnCorrectTaxRate(int months, decimal expectedTaxRate)
        {
            // Act
            var taxRate = CdbInvestment.GetTaxRate(months);

            // Assert
            Assert.Equal(expectedTaxRate, taxRate);
        }
    }
}