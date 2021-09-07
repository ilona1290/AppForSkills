using MediatR;

namespace AppForSkills.Application.Users.Queries.GetUserRatings
{
    public class GetUserRatingsQuery : IRequest<RatingsVm>
    {
        public string Username { get; set; }
    }
}
