using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Theatre
    {
        public Theatre()
        {
            Seats = new HashSet<Seats>();
            ShowTime = new HashSet<ShowTime>();
        }

        public int TheatreId { get; set; }
        public string TheatreName { get; set; }
        public int? CityId { get; set; }
        public string Location { get; set; }
        public bool? IsActive { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Seats> Seats { get; set; }
        public virtual ICollection<ShowTime> ShowTime { get; set; }
    }
}
