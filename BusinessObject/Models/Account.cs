using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Account
    {
        public Account()
        {
            Babies = new HashSet<Baby>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
            UserVouchers = new HashSet<UserVoucher>();
        }

        public int AccountId { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<Baby> Babies { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<UserVoucher> UserVouchers { get; set; }
    }
}
