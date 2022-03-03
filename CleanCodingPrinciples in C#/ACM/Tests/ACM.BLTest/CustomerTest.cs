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
            var customer = new Customer { FirstName = "Bilbo", LastName = "Baggins" };
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
            var customer = new Customer { LastName = "Baggins" };
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
            var customer = new Customer { FirstName = "Bilbo"};
            string expected = "Bilbo";
            // Act
            string actual = customer.FullName;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StaticTest () {
            // Arrange
            var c1 = new Customer { FirstName = "Bilbo" };
            Customer.InstanceCount++;
            var c2 = new Customer { FirstName = "Frodo" };
            Customer.InstanceCount++;
            var c3 = new Customer { FirstName = "Rosie" };
            Customer.InstanceCount++;
            // Act
            // Assert
            Assert.Equal(3, Customer.InstanceCount);

        }
    }
}
