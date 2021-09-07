using MediatR;

namespace AppForSkills.Application.SkillPosts.Queries.GetRatingsToSkillPost
{
    public class GetRatingsToSkillPostQuery : IRequest<RatingsPostVm>
    {
        public int SkillId { get; set; }
    }
}
