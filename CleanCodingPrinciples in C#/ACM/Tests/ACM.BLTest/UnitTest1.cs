using System;
using Xunit;
using ACM.BL;

namespace ACM.BLTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            Customer customer = new Customer { FirstName = "Bilbo", LastName = "Baggins" };
            string expected = "Baggins, Bilbo";
            // Act
            string actual = customer.FullName;
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
