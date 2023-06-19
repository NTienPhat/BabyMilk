using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class UserVoucherCreateDTO
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int VoucherId { get; set; }
    }
}
