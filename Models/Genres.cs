using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Movies = new HashSet<Movies>();
        }

        public int GenreId { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }
}
