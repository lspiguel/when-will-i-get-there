using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhenWillIGetThere.Data
{
    public static partial class ApplicationDbExtensions
    {
        public static readonly string AppUserIdClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

        public static string CurrentUserId(this Microsoft.AspNetCore.Mvc.ControllerBase c)
        {
            return c.User
                    .Claims
                    .Where(c => c.Type == AppUserIdClaimType)
                    .FirstOrDefault()
                    .Value;
        }
    }
}
