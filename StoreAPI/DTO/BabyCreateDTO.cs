using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class BabyCreateDTO
    {
        //[Key]
        //public int BabyId { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime Dob { get; set; }
        public string? Gender { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        [Required]
        [ValidateNever]
        public int AccountId { get; set; }
    }
}
