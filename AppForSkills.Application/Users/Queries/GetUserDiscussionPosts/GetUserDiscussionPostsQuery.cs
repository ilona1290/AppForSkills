using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserDiscussionPosts
{
    public class GetUserDiscussionPostsQuery : IRequest<UserDiscussionPostsVm>
    {
        public string Username { get; set; }
    }
}
