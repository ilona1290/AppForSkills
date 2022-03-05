using FluentValidation;

namespace AppForSkills.Application.Discussions.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(p => p.DiscussionId).NotNull().GreaterThan(0);
            RuleFor(p => p.PostText).NotEmpty().MaximumLength(500);
            RuleFor(p => p.MainParentPostId).GreaterThan(0).When(p => p.MainParentPostId != null);
            RuleFor(p => p.ParentPostId).GreaterThan(0).When(p => p.ParentPostId != null);
        }
    }
}
