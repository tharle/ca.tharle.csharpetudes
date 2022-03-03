using System;
using Xunit;
using ACM.BL;

namespace ACM.BLTest
{
    public class OrderRepositoryTest
    {
        [Fact]
        public void RetriveValid()
        {
            var repository = new OrderRepository();
            var expected = new Order(1)
            {
                OrderDate = new DateTimeOffset(2021, 11, 06, 09, 0, 0, new TimeSpan(-5,0,0))
            };

            var actual = repository.Retrive(1);

            Assert.Equal(expected.OrderId, actual.OrderId);
            Assert.Equal(expected.OrderDate, actual.OrderDate);
        }

        [Fact]
        public void RetriveFaild()
        {
            var repository = new OrderRepository();

            var actual = repository.Retrive(2);

            Assert.Null(actual);
        }
    }
}
