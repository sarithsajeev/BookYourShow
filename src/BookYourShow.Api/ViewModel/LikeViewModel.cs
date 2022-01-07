using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.ViewModel
{
    public class LikeViewModel
    {
        public int LikeId { get; set; }
        public int? MovieId { get; set; }
        public int? UserId { get; set; }
        public bool? IsActive { get; set; }
        public string MovieTitle { get; set; }
        public string UserName { get; set; }
    }
}
