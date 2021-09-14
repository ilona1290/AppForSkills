using FluentValidation;

namespace AppForSkills.Application.Likes.Commands.Unlike
{
    public class UnlikeCommandValidator : AbstractValidator<UnlikeCommand>
    {
        public UnlikeCommandValidator()
        {
            RuleFor(u => u.LikeId).GreaterThan(0);
        }
    }
}
