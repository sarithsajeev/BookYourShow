using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.ViewModel
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ShowTimeStart { get; set; }
        public string TheatreName { get; set; }
        public string UserName { get; set; }
        public int? TicketCount { get; set; }
        public string PaymentInfo { get; set; }
    }
}
