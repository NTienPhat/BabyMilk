﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public string Type { get; set; } = null!;
        public string? TokenPayment { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
