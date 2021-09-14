using MediatR;

namespace AppForSkills.Application.Users.Queries.GetUserInformation
{
    public class GetUserInformationQuery : IRequest<UserInformationVm>
    {
        public string Username { get; set; }
    }
}
