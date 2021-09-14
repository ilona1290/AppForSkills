using FluentValidation;

namespace AppForSkills.Application.Discussions.Commands.DeletePost
{
    public class DeletePostValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostValidator()
        {
            RuleFor(p => p.PostId).GreaterThan(0);
        }
    }
}
