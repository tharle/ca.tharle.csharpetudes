using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderItem
    {
        public OrderItem(){}
        public int OrderItemId { get; private set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal? PurchasePrice { get; set; }

        /// <summary>
        /// Validates the orderItem data
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if (ProductId <= 0) return false;
            if (Quantity <= 0) return false;
            if (PurchasePrice == null || PurchasePrice < 0) return false;

            return true;
        }

        /// <summary>
        /// Retrive one orderItem by Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public OrderItem Retrive(int orderId)
        {
            // Code that retrives the defined orderItem
            return new OrderItem();
        }

        /// <summary>
        /// Retrive all ordersItems
        /// </summary>
        /// <returns></returns>
        public List<OrderItem> Retrive()
        {
            // Code that retrives all of the ordersItems
            return new List<OrderItem>();
        }

        /// <summary>
        /// Saves the current orderItem
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined orderItem
            return true;
        }
    }
}
