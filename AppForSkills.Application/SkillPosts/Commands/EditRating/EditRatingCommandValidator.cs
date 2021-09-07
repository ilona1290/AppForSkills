using FluentValidation;

namespace AppForSkills.Application.SkillPosts.Commands.EditRating
{
    public class EditRatingCommandValidator : AbstractValidator<EditRatingCommand>
    {
        public EditRatingCommandValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0);
            RuleFor(r => r.Value).GreaterThan(0).LessThanOrEqualTo(5);
        }
    }
}
