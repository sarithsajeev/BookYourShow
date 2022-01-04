using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.ViewModel
{
    public class CastViewModel
    {
        public int CastId { get; set; }
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public int? MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }

    }
}