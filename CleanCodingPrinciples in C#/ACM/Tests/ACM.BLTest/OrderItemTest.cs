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
                ProductId = 5893,
                Quantity = 1,
                PurchasePrice = new Decimal(5.8)

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
                PurchasePrice = new Decimal(5.8)

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
                ProductId = 5893,
                PurchasePrice = new Decimal(5.8)

            };
            // Assert
            Assert.False(orderItem.Validate(), "That test should be invalid");
        }

        [Fact]
        public void ValidateMissingPurchasePrice()
        {
            // Arrange
            var orderItem = new OrderItem()
            {
                ProductId = 5893,
                Quantity = 1

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
                ProductId = 5893,
                Quantity = 1,
                PurchasePrice = new Decimal(-3.5f) 

            };
            // Assert
            Assert.False(orderItem.Validate(), "That test should be invalid");
        }

    }
}
