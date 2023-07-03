using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class DevelopmentCreateDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [Range(0, 200)]
        public int MinMonth { get; set; }
        [Required]
        [Range(0, 200)]
        public int MaxMonth { get; set; }
        [Required]
        public string Descript { get; set; } = null!;
    }
}
