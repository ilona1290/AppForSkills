using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(p => p.DiscussionId).NotNull().GreaterThan(0);
            RuleFor(p => p.PostText).NotEmpty().MaximumLength(500);
            RuleFor(p => p.ParentPostId).GreaterThan(0).When(p => p.ParentPostId != null);
        }
    }
}
