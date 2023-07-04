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

        public int OrderVoucherId { get; set; }
        public int VoucherId { get; set; }

        public virtual Voucher Voucher { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
