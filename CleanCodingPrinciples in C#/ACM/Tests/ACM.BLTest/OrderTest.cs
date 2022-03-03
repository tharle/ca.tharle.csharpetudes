using System;
using Xunit;
using ACM.BL;

namespace ACM.BLTest
{
    public class OrderTest
    {
        [Fact]
        public void ValidateValid()
        {
            // Arrange
            var order = new Order()
            {
                OrderDate = DateTime.Today
            };
            // Assert
            Assert.True(order.Validate(), "That test should be valid");
        }

        [Fact]
        public void ValidateMissingDateOrder()
        {
            // Arrange
            var order = new Order();
            // Assert
            Assert.False(order.Validate(), "That test should be invalid");
        }
    }
}
