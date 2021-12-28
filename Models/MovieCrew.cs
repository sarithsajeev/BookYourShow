using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class MovieCrew
    {
        public int MovieCrewId { get; set; }
        public int? MemberId { get; set; }
        public string RoleName { get; set; }
        public int? MovieId { get; set; }

        public virtual Crew Member { get; set; }
        public virtual Movies Movie { get; set; }
    }
}
