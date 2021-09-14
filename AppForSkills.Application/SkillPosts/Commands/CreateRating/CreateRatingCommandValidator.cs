using FluentValidation;

namespace AppForSkills.Application.SkillPosts.Commands.CreateRating
{
    public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
    {
        public CreateRatingCommandValidator()
        {
            RuleFor(r => r.Value).GreaterThan(0).LessThanOrEqualTo(5);
            RuleFor(r => r.SkillPostId).GreaterThan(0);
        }
    }
}
