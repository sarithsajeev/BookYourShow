using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Likes
    {
        public int LikeId { get; set; }
        public int? MovieId { get; set; }
        public int? UserId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Movies Movie { get; set; }
        public virtual Users User { get; set; }
    }
}
