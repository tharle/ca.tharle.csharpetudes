﻿using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order : EntityBase, ILoggable
    {
        public Order() : this(0) { }
        public Order(int orderId) { OrderId = orderId;  OrderItems = new List<OrderItem>(); }

        public int OrderId { get; private set; }
        public DateTimeOffset? OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int QntItems { get => OrderItems.Count; }

        public string Log() => $"{OrderId}: {OrderDate.Value.Date}; Qnt of items: {QntItems}; Status:{EntityState}";

        public override string ToString() => $"{OrderDate.Value.Date} ({OrderId})";

        /// <summary>
        /// Validates the order data
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (OrderDate == null) return false;
            return true;
        }
    }
}
