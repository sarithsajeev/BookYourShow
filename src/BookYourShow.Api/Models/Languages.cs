using System;
using System.Collections.Generic;

namespace BookYourShow.Models
{
    public partial class Languages
    {
        public Languages()
        {
            Movies = new HashSet<Movies>();
        }

        public int LangId { get; set; }
        public string Language { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }
}
