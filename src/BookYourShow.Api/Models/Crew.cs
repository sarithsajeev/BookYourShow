using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Crew
    {
        public Crew()
        {
            MovieCrew = new HashSet<MovieCrew>();
        }

        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<MovieCrew> MovieCrew { get; set; }
    }
}
