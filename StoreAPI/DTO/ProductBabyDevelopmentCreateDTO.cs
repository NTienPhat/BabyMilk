using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class ProductBabyDevelopmentCreateDTO
    {
        //[Key]
        //public int ProductBabyDevelopmentId { get; set; }
        [Required]
        public int MilestonesByMonthId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
