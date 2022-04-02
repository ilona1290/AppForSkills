using FluentValidation;

namespace AppForSkills.Application.Likes.Commands.GiveLike
{
    public class GiveLikeCommandValidator : AbstractValidator<GiveLikeCommand>
    {
        public GiveLikeCommandValidator()
        {
            RuleFor(l => l.User).NotEmpty();
        }
    }
}
