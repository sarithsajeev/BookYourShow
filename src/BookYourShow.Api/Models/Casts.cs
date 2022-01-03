using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Casts
    {
        public int CastId { get; set; }
        public int? ActorId { get; set; }
        public string RoleName { get; set; }
        public int? MovieId { get; set; }

        public virtual Actors Actor { get; set; }
        public virtual Movies Movie { get; set; }
    }
}
