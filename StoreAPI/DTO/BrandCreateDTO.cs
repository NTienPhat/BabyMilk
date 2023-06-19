using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class BrandCreateDTO
    {
        [Required]
        public string BrandName { get; set; } = null!;
    }
}
