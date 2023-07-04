using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class BabyTakeCare
    {
        public BabyTakeCare()
        {
            TakeCareDevelopments = new HashSet<TakeCareDevelopment>();
        }

        public int BabyTakeCareId { get; set; }
        public int Month { get; set; }
        public string? Post { get; set; }

        public virtual ICollection<TakeCareDevelopment> TakeCareDevelopments { get; set; }
    }
}
