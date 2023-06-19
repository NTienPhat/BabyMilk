using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class BabyDevelopmentCreateDTO
    {
        [Required]
        public int DevelopmentId { get; set; }
        [Required]
        public int BabyId { get; set; }
    }
}
