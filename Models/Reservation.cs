using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            Seats = new HashSet<Seats>();
        }

        public int ReservationId { get; set; }
        public int? ShowTimeId { get; set; }
        public int? UserId { get; set; }
        public int? TicketCount { get; set; }
        public string PaymentInfo { get; set; }

        public virtual ShowTime ShowTime { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Seats> Seats { get; set; }
    }
}
