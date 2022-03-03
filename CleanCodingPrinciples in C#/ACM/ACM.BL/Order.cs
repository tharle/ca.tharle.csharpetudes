using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order
    {
        public int OrderId { get; private set; }
        public DateTime OrderDate { get; set; }


        /// <summary>
        /// Validates the order data
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if (DateTime.Equals(OrderDate, DateTime.MinValue)) return false;
            return true;
        }

        /// <summary>
        /// Retrive one order by Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order Retrive(int orderId)
        {
            // Code that retrives the defined order
            return new Order();
        }

        /// <summary>
        /// Retrive all orders
        /// </summary>
        /// <returns></returns>
        public List<Order> Retrive()
        {
            // Code that retrives all of the orders
            return new List<Order>();
        }

        /// <summary>
        /// Saves the current order
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined order
            return true;
        }
    }
}
