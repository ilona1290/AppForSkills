using FluentValidation;

namespace AppForSkills.Application.SkillPosts.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.CommentText).NotEmpty().MaximumLength(500);
            RuleFor(c => c.ParentCommentId).GreaterThan(0).When(c => c.ParentCommentId != null);
            RuleFor(c => c.MainParentCommentId).GreaterThan(0).When(c => c.MainParentCommentId != null);
            RuleFor(c => c.SkillPostId).GreaterThan(0);
        }
    }
}
