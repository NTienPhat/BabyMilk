using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class MilestonesByMonthCreateDTO
    {
        //[Key]
        //public int MilestonesByMonthId { get; set; }
        [Required]
        [Range(0,36)]
        public int MinMonth { get; set; }
        [Required]
        [Range(0, 36)]
        public int MaxMonth { get; set; }
    }
}
