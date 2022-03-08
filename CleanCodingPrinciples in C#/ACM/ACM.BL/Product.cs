using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product : EntityBase, ILoggable
    {
        public Product() { }
        public Product(int productId) { ProductId = productId; }

        public int ProductId { get; private set; }
        private string _productName;
        public string ProductName {
            get
            {
                return _productName.InsertSpaces();
            }
            set
            {
                _productName = value;
            }
        }
        public string Description { get; set; }
        public Decimal? CurrentPrice { get; set; }

        public string Log() => $"{ProductId}: {ProductName}; Description: {Description}; Status: {EntityState}";

        public override string ToString() => ProductName;

        /// <summary>
        /// Validates the product data
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (String.IsNullOrWhiteSpace(ProductName)) return false;
            if (CurrentPrice == null || CurrentPrice < 0) return false;
            return true;
        }
    }
}
