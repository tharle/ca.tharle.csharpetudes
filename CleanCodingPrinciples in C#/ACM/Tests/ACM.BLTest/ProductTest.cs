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
                ProductName = "Book"
            };
            // Assert
            Assert.True(product.Validate(), "That test should be valid");
        }

        [Fact]
        public void ValidateMissingProductNameValid()
        {
            // Arrange
            var product = new Product();
            // Assert
            Assert.False(product.Validate(), "That test should be invalid");
        }
    }
}
