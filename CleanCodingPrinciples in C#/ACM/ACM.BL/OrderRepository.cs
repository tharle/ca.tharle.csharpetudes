using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderRepository
    {

        /// <summary>
        /// Retrive one order by Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order Retrive(int orderId)
        {
            if(orderId == 1)
            {
                return new Order(1)
                {
                    OrderDate = new DateTimeOffset(2021, 11, 06, 09, 0, 0, new TimeSpan(-5, 0, 0))
                };
            }

            // Code that retrives the defined order
            return null;
        }

        /// <summary>
        /// Saves the current order
        /// </summary>
        /// <returns></returns>
        public bool Save(Order order)
        {
            if (!order.HasChanges) return true;

            if (!order.IsValid) return false;

            if (order.IsNew)
            {
                // Call an Insert Stored PRoducedure
                return true;
            }
            else
            {
                // Call an update stored procedure
                return true;
            }
        }
    }
}
