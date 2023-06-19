using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderVoucher
    {
        public OrderVoucher()
        {
            Orders = new HashSet<Order>();
        }

        public int ProductVoucherId { get; set; }
        public int VoucherId { get; set; }
        public int ProductId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
