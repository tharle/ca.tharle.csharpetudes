using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class ProductRepository
    {
        /// <summary>
        /// Retrive one product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product Retrive(int productId)
        {
            // Code that retrives the defined product

            if(productId == 1)
            {
                return new Product(1)
                {
                    ProductName = "Book",
                    Description = "You can read infos from this object.",
                    CurrentPrice = 3.45m
                };
            }

            if (productId == 2)
            {
                return new Product(2)
                {
                    ProductName = "SunFlowers",
                    Description = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers.",
                    CurrentPrice = 15.96m
                };
            }

            return null;
        }

        /// <summary>
        /// Retrive all products
        /// </summary>
        /// <returns></returns>
        public List<Product> Retrive()
        {
            // Code that retrives all of the products
            return new List<Product>();
        }

        /// <summary>
        /// Saves the current product
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined product
            return true;
        }
    }
}
