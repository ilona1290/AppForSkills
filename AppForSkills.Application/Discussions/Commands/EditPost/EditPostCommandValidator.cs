using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.EditPost
{
    public class EditPostCommandValidator : AbstractValidator<EditPostCommand>
    {
        public EditPostCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
            RuleFor(w => w.PostText).NotEmpty().MinimumLength(500);
        }
    }
}
