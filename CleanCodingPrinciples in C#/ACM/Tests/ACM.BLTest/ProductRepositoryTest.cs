using System;
using Xunit;
using ACM.BL;

namespace ACM.BLTest
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void RetriveValid()
        {
            var repository = new ProductRepository();
            var expected = new Product(2)
            {
                ProductName = "SunFlowers",
                Description = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers.",
                CurrentPrice = 15.96m
            };

            var actual = repository.Retrive(2);

            Assert.Equal(expected.ProductId, actual.ProductId);
            Assert.Equal(expected.ProductName, actual.ProductName);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.CurrentPrice, actual.CurrentPrice);
        }

        [Fact]
        public void RetriveFaild()
        {
            var repository = new ProductRepository();

            var actual = repository.Retrive(23);

            Assert.Null(actual);
        }
    }
}
