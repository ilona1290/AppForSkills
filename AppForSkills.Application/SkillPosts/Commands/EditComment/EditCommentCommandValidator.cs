using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
