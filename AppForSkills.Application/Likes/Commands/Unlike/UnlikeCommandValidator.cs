using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
