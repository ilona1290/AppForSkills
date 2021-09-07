using MediatR;

namespace AppForSkills.Application.SkillPosts.Commands.DeleteSkillPost
{
    public class DeleteSkillPostCommand : IRequest
    {
        public int SkillPostId { get; set; }
    }
}
