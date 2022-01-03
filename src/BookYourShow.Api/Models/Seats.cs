using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Seats
    {
        public int SeatId { get; set; }
        public string Row { get; set; }
        public int? Number { get; set; }
        public bool? Status { get; set; }
        public int? ReservationId { get; set; }
        public int? TheatreId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Theatre Theatre { get; set; }
    }
}
