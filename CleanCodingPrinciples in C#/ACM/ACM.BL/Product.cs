using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float CurrentPrice { get; set; }


        /// <summary>
        /// Validates the product data
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if (String.IsNullOrWhiteSpace(ProductName)) return false;
            return true;
        }

        /// <summary>
        /// Retrive one product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product Retrive(int productId)
        {
            // Code that retrives the defined product
            return new Product();
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
