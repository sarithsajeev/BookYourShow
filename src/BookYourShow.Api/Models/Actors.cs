using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Actors
    {
        public Actors()
        {
            Casts = new HashSet<Casts>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Casts> Casts { get; set; }
    }
}
