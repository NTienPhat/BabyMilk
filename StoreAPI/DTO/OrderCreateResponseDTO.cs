using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class OrderCreateResponseDTO
    {
        public int AccountId { get; set; }
        public string ShippingAddress { get; set; } = null!;
        public decimal Prices { get; set; }
        public int TotalQuantity { get; set; }
        public int? ProductVoucherId { get; set; }
        public string Token { get; set; }
    }
}
