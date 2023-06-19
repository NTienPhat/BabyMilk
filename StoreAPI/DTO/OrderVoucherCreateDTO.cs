using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class OrderVoucherCreateDTO
    {
        [Required]
        public int VoucherId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
