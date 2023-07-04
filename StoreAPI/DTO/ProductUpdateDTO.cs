using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class ProductUpdateDTO
    {
        //[Key]
        //public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        //public string Img { get; set; } = null!;
        public IFormFile? File { get; set; }
        [Range(0, 5)]
        public decimal? Rating { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Status { get; set; } = null!;
        [Required]
        [Range(0, 2000000)]
        public decimal Price { get; set; }
        [Required]
        public int BrandId { get; set; }
        [ValidateNever]
        public int? ProductBabyDevelopmentId { get; set; }
        [Required]
        [Range(0, 200)]
        public int Quantity { get; set; }
    }
}
