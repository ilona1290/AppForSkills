using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.Account
{
    public class RegisterUserToAPIVm
    {
        public string Username { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime RecentLoginDate { get; set; }
    }
}
