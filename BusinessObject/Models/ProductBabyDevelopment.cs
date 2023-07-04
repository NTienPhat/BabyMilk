using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ProductBabyDevelopment
    {
        public int ProductBabyDevelopmentId { get; set; }
        public int MilestonesByMonthId { get; set; }
        public int ProductId { get; set; }

        public virtual MilestonesByMonth MilestonesByMonth { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
