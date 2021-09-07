using FluentValidation;

namespace AppForSkills.Application.SkillPosts.Commands.EditComment
{
    public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);
            RuleFor(c => c.CommentText).NotEmpty().MinimumLength(500);
        }
    }
}
