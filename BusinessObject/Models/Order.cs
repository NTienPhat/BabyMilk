using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Payments = new HashSet<Payment>();
        }

        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; } = null!;
        public string OrderStatus { get; set; } = null!;
        public decimal Prices { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ProductVoucherId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual OrderVoucher? ProductVoucher { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
