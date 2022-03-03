using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order
    {
        public Order() { }
        public Order(int orderId) { OrderId = orderId; }
        public int OrderId { get; private set; }
        public DateTimeOffset? OrderDate { get; set; }


        /// <summary>
        /// Validates the order data
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if (OrderDate == null) return false;
            return true;
        }
    }
}
