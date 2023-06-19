using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ProductBabyDevelopment
    {
        public ProductBabyDevelopment()
        {
            MilestonesByMonths = new HashSet<MilestonesByMonth>();
            Products = new HashSet<Product>();
        }

        public int ProductBabyDevelopmentId { get; set; }
        public int MilestonesByMonthId { get; set; }
        public int ProductId { get; set; }

        public virtual MilestonesByMonth MilestonesByMonth { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<MilestonesByMonth> MilestonesByMonths { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
