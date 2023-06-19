using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Baby
    {
        public Baby()
        {
            BabyDevelopments = new HashSet<BabyDevelopment>();
        }

        public int BabyId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string? Gender { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<BabyDevelopment> BabyDevelopments { get; set; }
    }
}
