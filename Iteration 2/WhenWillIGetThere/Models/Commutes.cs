using System;
using System.Collections.Generic;

namespace WhenWillIGetThere.Models
{
    public partial class Commutes
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Stop { get; set; }

        public virtual Routes Route { get; set; }
    }
}
