using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.ViewModel
{
    public class TicketViewModel
    {
        public string UserName { get; set; }
        public decimal? ContactNumber { get; set; }
        public string Movie { get; set; }
        public string TheatreName { get; set; }
        public int? SeatNumber { get; set; }
        public int? TicketCount { get; set; }
    }
}
