using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Likes.Commands.GiveLike
{
    public class GiveLikeCommandValidator : AbstractValidator<GiveLikeCommand>
    {
        public GiveLikeCommandValidator()
        {
            RuleFor(l => l.CommentId).GreaterThan(0);
            RuleFor(l => l.DiscussionId).GreaterThan(0);
            RuleFor(l => l.PostInDiscussionId).GreaterThan(0);
            RuleFor(l => l.User).NotEmpty();
        }
    }
}
