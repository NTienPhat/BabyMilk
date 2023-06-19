using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            UserVouchers = new HashSet<UserVoucher>();
        }

        public int VoucherId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Discount { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<UserVoucher> UserVouchers { get; set; }
    }
}
