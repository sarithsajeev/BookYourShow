using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class City
    {
        public City()
        {
            Theatre = new HashSet<Theatre>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public bool? IsActive { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }

        public virtual ICollection<Theatre> Theatre { get; set; }
    }
}
