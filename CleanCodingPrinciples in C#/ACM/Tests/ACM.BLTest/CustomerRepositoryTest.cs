using System;
using Xunit;
using ACM.BL;

namespace ACM.BLTest
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public void RetriveValid()
        {
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            };

            var actual = customerRepository.Retrive(1);

            Assert.Equal(expected.CustomerId, actual.CustomerId);
            Assert.Equal(expected.EmailAddress, actual.EmailAddress);
            Assert.Equal(expected.FullName, actual.FullName);
            Assert.Equal(2, actual.Addresses.Count);
        }

        [Fact]
        public void RetriveFaild()
        {
            var customerRepository = new CustomerRepository();

            var actual = customerRepository.Retrive(2);

            Assert.Null(actual);
        }
    }
}
