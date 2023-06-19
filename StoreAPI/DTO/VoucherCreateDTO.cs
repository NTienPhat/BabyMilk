using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class VoucherCreateDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public string Type { get; set; } = null!;
    }
}
