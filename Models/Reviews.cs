using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public int? MovieId { get; set; }
        public string Comments { get; set; }

        public virtual Movies Review { get; set; }
    }
}
