﻿using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class OrderCreateDTO
    {
        //[Key]
        //public int OrderId { get; set; }
        [Required]
        [ValidateNever]
        public int AccountId { get; set; }
        [Required]
        public string ShippingAddress { get; set; } = null!;
        [Required]
        public decimal Prices { get; set; }
        [Required]
        public int TotalQuantity { get; set; }
        public int? ProductVoucherId { get; set; }
        //public ICollection<OrderDetailsCreateDTO> OrderDetails { get; set; }
    }
}
