using MediatR;

namespace AppForSkills.Application.Users.Queries.GetUserComments
{
    public class GetUserCommentsQuery : IRequest<CommentsVm>
    {
        public string Username { get; set; }
    }
}
