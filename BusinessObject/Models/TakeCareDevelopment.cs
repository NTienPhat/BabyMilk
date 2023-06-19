using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class TakeCareDevelopment
    {
        public int TakeCareDevelopmentId { get; set; }
        public int BabyTakeCareId { get; set; }
        public int DevelopmentId { get; set; }

        public virtual BabyTakeCare BabyTakeCare { get; set; } = null!;
        public virtual Development Development { get; set; } = null!;
    }
}
