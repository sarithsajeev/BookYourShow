using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Offers
    {
        public Offers()
        {
            Movies = new HashSet<Movies>();
        }

        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public string OfferDescription { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }
}
