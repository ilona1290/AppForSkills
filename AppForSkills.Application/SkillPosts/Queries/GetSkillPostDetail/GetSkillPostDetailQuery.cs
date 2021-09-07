using MediatR;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class GetSkillPostDetailQuery : IRequest<SkillPostVm>
    {
        public int SkillPostId { get; set; }
    }
}
