using BusinessObject.Models;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class PaymentCreateDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string Type { get; set; } = null!;
        public string? TokenPayment { get; set; }
    }
}
