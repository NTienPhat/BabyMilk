using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class MilestonesByMonth
    {
        public MilestonesByMonth()
        {
            ProductBabyDevelopments = new HashSet<ProductBabyDevelopment>();
        }

        public int MilestonesByMonthId { get; set; }
        public int MinMonth { get; set; }
        public int MaxMonth { get; set; }
        public int ProductBabyDevelopmentId { get; set; }

        public virtual ProductBabyDevelopment ProductBabyDevelopment { get; set; } = null!;
        public virtual ICollection<ProductBabyDevelopment> ProductBabyDevelopments { get; set; }
    }
}
