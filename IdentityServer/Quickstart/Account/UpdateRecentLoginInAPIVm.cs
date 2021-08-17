using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.Account
{
    public class UpdateRecentLoginInAPIVm
    {
        public string Username { get; set; }
        public DateTime RecentLogin { get; set; }
    }
}
