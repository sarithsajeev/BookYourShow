using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Users
    {
        public Users()
        {
            Likes = new HashSet<Likes>();
            Reservation = new HashSet<Reservation>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? ContactNumber { get; set; }

        public virtual ICollection<Likes> Likes { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
