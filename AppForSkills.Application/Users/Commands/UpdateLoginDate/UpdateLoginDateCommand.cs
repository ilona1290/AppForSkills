using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Commands.UpdateLoginDate
{
    public class UpdateLoginDateCommand : IRequest
    {
        public string Username { get; set; }
        public DateTime RecentLogin { get; set; }
    }
}
