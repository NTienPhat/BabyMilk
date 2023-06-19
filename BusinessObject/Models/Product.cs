using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductBabyDevelopments = new HashSet<ProductBabyDevelopment>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Img { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public int? ProductBabyDevelopmentId { get; set; }
        public int Quantity { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ProductBabyDevelopment? ProductBabyDevelopment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductBabyDevelopment> ProductBabyDevelopments { get; set; }
    }
}
