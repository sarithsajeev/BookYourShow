using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.ViewModel
{
    public class MovieViewModel
    {
        public int? MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDesc { get; set; }
        public DateTime? MovieRelease { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string OfferName { get; set; }
        public string OfferDescription { get; set; }
        public bool? IsActive { get; set; }
    }
}
