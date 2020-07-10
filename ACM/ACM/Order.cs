﻿using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM
{
    public class Order : EntityBase, ILoggable
    {
        public Order() : this(0)
        {

        }

        public Order(int orderId)
        {
            this.OrderId = orderId;
            OrderItems = new List<OrderItem>();
        }

        public int CustomerId { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public int OrderId { get; private set; }
        public List<OrderItem> OrderItems { get; set; }
        public int ShippingAddressId { get; set; }

        public string Log() => $"{OrderId}: Date: {this.OrderDate.Value.Date} Status: {this.EntityState}";

        public override string ToString() => OrderDate.ToString() + OrderId;

        public override bool Validate()
        {
            var isValid = true;

            if (OrderDate == null) isValid = false;

            return isValid;
        }
    }
}