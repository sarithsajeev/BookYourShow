using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.ViewModel
{
    public class ShowTimeView
    {
        public int ShowTimeId { get; set; }
        public int? MovieId { get; set; }
        public int? TheatreId { get; set; }
        public DateTime ShowTimeStart { get; set; }
        public string TheatreName { get; set; }
    }
}
