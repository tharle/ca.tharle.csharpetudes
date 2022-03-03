using System;
using Xunit;
using ACM.BL;

namespace ACM.BLTest
{
    public class CustomerTest
    {
        [Fact]
        public void FullNameTestValid()
        {
            // Arrange
            Customer customer = new Customer { FirstName = "Bilbo", LastName = "Baggins" };
            string expected = "Baggins, Bilbo";
            // Act
            string actual = customer.FullName;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FullNameFirstNameEmpty()
        {
            // Arrange
            Customer customer = new Customer { LastName = "Baggins" };
            string expected = "Baggins";
            // Act
            string actual = customer.FullName;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FullNameLastNameEmpty()
        {
            // Arrange
            Customer customer = new Customer { FirstName = "Bilbo"};
            string expected = "Bilbo";
            // Act
            string actual = customer.FullName;
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
