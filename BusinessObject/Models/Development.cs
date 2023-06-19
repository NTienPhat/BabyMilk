using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Development
    {
        public Development()
        {
            BabyDevelopments = new HashSet<BabyDevelopment>();
            TakeCareDevelopments = new HashSet<TakeCareDevelopment>();
        }

        public int DevelopmentId { get; set; }
        public string Name { get; set; } = null!;
        public int MinMonth { get; set; }
        public int MaxMonth { get; set; }
        public string Descript { get; set; } = null!;

        public virtual ICollection<BabyDevelopment> BabyDevelopments { get; set; }
        public virtual ICollection<TakeCareDevelopment> TakeCareDevelopments { get; set; }
    }
}
