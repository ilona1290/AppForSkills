using MediatR;

namespace AppForSkills.Application.SkillPosts.Commands.DeleteRating
{
    public class DeleteRatingCommand : IRequest
    {
        public int RatingId { get; set; }
    }
}
