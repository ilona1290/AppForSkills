using MediatR;

namespace AppForSkills.Application.SkillPosts.Commands.EditRating
{
    public class EditRatingCommand : IRequest
    {
        public int Id { get; set; }
        public int Value { get; set; }

    }
}
