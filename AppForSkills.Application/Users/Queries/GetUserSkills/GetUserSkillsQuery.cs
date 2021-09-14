using AppForSkills.Application.SkillPosts.Queries.GetSkillPosts;
using MediatR;

namespace AppForSkills.Application.Users.Queries.GetUserSkills
{
    public class GetUserSkillsQuery : IRequest<SkillPostsVm>
    {
        public string Username { get; set; }
    }
}
