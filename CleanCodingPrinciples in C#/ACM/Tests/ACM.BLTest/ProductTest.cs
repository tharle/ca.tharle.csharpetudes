using System;
using Xunit;
using ACM.BL;

namespace ACM.BLTest
{
    public class ProductTest
    {
        [Fact]
        public void ValidateValid()
        {
            // Arrange
            var product = new Product()
            {
                ProductName = "Book",
                CurrentPrice = new Decimal(5.8)
            };
            // Assert
            Assert.True(product.Validate(), "That test should be valid");
        }

        [Fact]
        public void ValidateMissingProductName()
        {
            // Arrange
            var product = new Product() {
                CurrentPrice = new Decimal(5.8)
            };
            // Assert
            Assert.False(product.Validate(), "That test should be invalid");
        }

        [Fact]
        public void ValidateMissingCurrentPrice()
        {
            // Arrange
            var product = new Product()
            {
                ProductName = "Book"
            };
            // Assert
            Assert.False(product.Validate(), "That test should be invalid");
        }

        [Fact]
        public void ValidateCurrentPriceNegative()
        {
            // Arrange
            var product = new Product()
            {
                ProductName = "Book",
                CurrentPrice = new Decimal(-2.8)
            };
            // Assert
            Assert.False(product.Validate(), "That test should be invalid");
        }
    }
}
