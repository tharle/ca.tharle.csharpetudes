using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product
    {
        public Product() { }
        public Product(int productId) { ProductId = productId; }

        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Decimal? CurrentPrice { get; set; }


        /// <summary>
        /// Validates the product data
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if (String.IsNullOrWhiteSpace(ProductName)) return false;
            if (CurrentPrice == null || CurrentPrice < 0) return false;
            return true;
        }
    }
}
