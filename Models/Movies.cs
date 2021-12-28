using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Movies
    {
        public Movies()
        {
            Casts = new HashSet<Casts>();
            Likes = new HashSet<Likes>();
            MovieCrew = new HashSet<MovieCrew>();
            ShowTime = new HashSet<ShowTime>();
        }

        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDesc { get; set; }
        public DateTime MovieRelease { get; set; }
        public int? LangId { get; set; }
        public int? GenreId { get; set; }
        public int? OfferId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Genres Genre { get; set; }
        public virtual Languages Lang { get; set; }
        public virtual Offers Offer { get; set; }
        public virtual Reviews Reviews { get; set; }
        public virtual ICollection<Casts> Casts { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
        public virtual ICollection<MovieCrew> MovieCrew { get; set; }
        public virtual ICollection<ShowTime> ShowTime { get; set; }
    }
}
