using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.CommentText).NotEmpty().MaximumLength(500);
            RuleFor(c => c.ParentCommentId).GreaterThan(0).When(c => c.ParentCommentId != null);
            RuleFor(c => c.SkillPostId).GreaterThan(0);
        }
    }
}
