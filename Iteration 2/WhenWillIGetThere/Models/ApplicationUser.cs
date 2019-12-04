﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhenWillIGetThere.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Routes> Routes { get; set; }
    }
}
