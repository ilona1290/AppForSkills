using Microsoft.AspNetCore.Identity;
using System;

namespace IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime Registration { get; set; }
        public DateTime RecentLogin { get; set; }
    }
}
