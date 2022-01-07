using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Api.ViewModel
{
    public class MovieCrewModel
    {
        public int MovieCrewId { get; set; }

        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string RoleName { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }


    }
}
