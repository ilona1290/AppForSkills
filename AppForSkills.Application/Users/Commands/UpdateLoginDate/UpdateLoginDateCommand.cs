using MediatR;
using System;

namespace AppForSkills.Application.Users.Commands.UpdateLoginDate
{
    public class UpdateLoginDateCommand : IRequest
    {
        public string Username { get; set; }
        public DateTime RecentLogin { get; set; }
    }
}
