using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class DevelopmentCreateDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [Range(6, int.MaxValue)]
        public int MinMonth { get; set; }
        [Required]
        [Range(6, int.MaxValue)]
        public int MaxMonth { get; set; }
        [Required]
        public string Descript { get; set; } = null!;
    }
}
