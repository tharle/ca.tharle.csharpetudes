using System;
using Xunit;
using ACM.BL;

namespace ACM.BLTest
{
    public class OrderItemTest
    {
        [Fact]
        public void ValidateValid()
        {
            // Arrange
            var orderItem = new OrderItem()
            {
                Product = new Product(),
                Quantity = 1,
                PurchasePrice = 5.8f

            };
            // Assert
            Assert.True(orderItem.Validate(), "That test should be valid");
        }

        [Fact]
        public void ValidateMissingProduct()
        {
            // Arrange
            var orderItem = new OrderItem()
            {
                Quantity = 1,
                PurchasePrice = 5.8f

            };
            // Assert
            Assert.False(orderItem.Validate(), "That test should be invalid");
        }

        [Fact]
        public void ValidateQuantityZero()
        {
            // Arrange
            var orderItem = new OrderItem()
            {
                Product = new Product(),
                PurchasePrice = 5.8f

            };
            // Assert
            Assert.False(orderItem.Validate(), "That test should be invalid");
        }

        [Fact]
        public void ValidatePurchasePriceNegative()
        {
            // Arrange
            var orderItem = new OrderItem()
            {
                Product = new Product(),
                Quantity = 1,
                PurchasePrice = -3.5f

            };
            // Assert
            Assert.False(orderItem.Validate(), "That test should be invalid");
        }

    }
}
