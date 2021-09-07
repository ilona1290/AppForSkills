using AppForSkills.Application.Discussions.GetDiscussions;
using MediatR;

namespace AppForSkills.Application.Users.Queries.GetUserDiscussions
{
    public class GetUserDiscussionsQuery : IRequest<DiscussionsVm>
    {
        public string Username { get; set; }
    }
}
