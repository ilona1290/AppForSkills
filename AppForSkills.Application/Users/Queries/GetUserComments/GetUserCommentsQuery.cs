using MediatR;

namespace AppForSkills.Application.Users.Queries.GetUserComments
{
    public class GetUserCommentsQuery : IRequest<UserCommentsVm>
    {
        public string Username { get; set; }
    }
}
