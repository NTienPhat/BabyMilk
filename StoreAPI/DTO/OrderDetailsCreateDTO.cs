using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class OrderDetailsCreateDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UnitPrice { get; set; }
    }
}
