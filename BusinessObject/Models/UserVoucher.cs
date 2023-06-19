using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class UserVoucher
    {
        public int UserVoucherId { get; set; }
        public int AccountId { get; set; }
        public int VoucherId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Voucher Voucher { get; set; } = null!;
    }
}
