using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class MilestonesByMonthCreateDTO
    {
        //[Key]
        //public int MilestonesByMonthId { get; set; }
        [Required]
        [Range(6,int.MaxValue)]
        public int MinMonth { get; set; }
        [Required]
        [Range(6, int.MaxValue)]
        public int MaxMonth { get; set; }
        [Required]
        [ValidateNever]
        public int ProductBabyDevelopmentId { get; set; }
    }
}
