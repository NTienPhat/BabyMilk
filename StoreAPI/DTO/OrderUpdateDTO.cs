using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class OrderUpdateDTO
    {
        [Required]
        public string OrderStatus { get; set; } = null!;
        public DateTime? ShippedDate { get; set; } = null!;
    }
}
