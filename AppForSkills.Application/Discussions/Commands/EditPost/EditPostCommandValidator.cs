using FluentValidation;

namespace AppForSkills.Application.Discussions.Commands.EditPost
{
    public class EditPostCommandValidator : AbstractValidator<EditPostCommand>
    {
        public EditPostCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
            RuleFor(w => w.PostText).NotEmpty().MaximumLength(500);
        }
    }
}
