using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class TakeCareDevelopmentCreateDTO
    {
        [Required]
        public int BabyTakeCareId { get; set; }
        [Required]
        public int DevelopmentId { get; set; }
    }
}
