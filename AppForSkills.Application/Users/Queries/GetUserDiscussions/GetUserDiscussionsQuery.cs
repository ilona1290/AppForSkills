using AppForSkills.Application.Discussions.GetDiscussions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserDiscussions
{
    public class GetUserDiscussionsQuery : IRequest<DiscussionsVm>
    {
        public string Username { get; set; }
    }
}
