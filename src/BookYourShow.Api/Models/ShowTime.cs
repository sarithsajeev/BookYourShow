using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class ShowTime
    {
        public ShowTime()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int ShowTimeId { get; set; }
        public int? MovieId { get; set; }
        public int? TheatreId { get; set; }
        public DateTime ShowTimeStart { get; set; }

        public virtual Movies Movie { get; set; }
        public virtual Theatre Theatre { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
