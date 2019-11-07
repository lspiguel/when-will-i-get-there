using System;
using System.Collections.Generic;

namespace WhenWillIGetThere.Models
{
    public partial class Routes
    {
        public Routes()
        {
            Commutes = new HashSet<Commutes>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Commutes> Commutes { get; set; }
    }
}
