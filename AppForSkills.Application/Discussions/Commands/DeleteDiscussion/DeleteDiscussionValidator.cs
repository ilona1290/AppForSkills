using FluentValidation;

namespace AppForSkills.Application.Discussions.Commands.DeleteDiscussion
{
    public class DeleteDiscussionValidator : AbstractValidator<DeleteDiscussionCommand>
    {
        public DeleteDiscussionValidator()
        {
            RuleFor(d => d.Id).GreaterThan(0);
        }
    }
}
