using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class BabyTakeCareCreateDTO
    {
        [Required]
        [Range(1, 300)]
        public int Month { get; set; }
        [Required]
        public string Post { get; set; } = null!;
    }
}
