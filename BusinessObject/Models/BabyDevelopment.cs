using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class BabyDevelopment
    {
        public int BabyDevelopmentId { get; set; }
        public int DevelopmentId { get; set; }
        public int BabyId { get; set; }

        public virtual Baby Baby { get; set; } = null!;
        public virtual Development Development { get; set; } = null!;
    }
}
