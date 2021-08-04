using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.EditDiscussion
{
    public class EditDiscussionCommandValidator : AbstractValidator<EditDiscussionCommand>
    {
        public EditDiscussionCommandValidator()
        {
            RuleFor(q => q.DiscussionId).GreaterThan(0);
            RuleFor(w => w.FirstPost).NotEmpty().MaximumLength(500);
        }
    }
}
