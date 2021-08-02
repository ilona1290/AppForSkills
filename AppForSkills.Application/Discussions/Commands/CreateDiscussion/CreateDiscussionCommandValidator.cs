using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.CreateDiscussion
{
    public class CreateDiscussionCommandValidator : AbstractValidator<CreateDiscussionCommand>
    {
        public CreateDiscussionCommandValidator()
        {
            RuleFor(d => d.FirstPost).NotEmpty().MaximumLength(500);
        }
    }
}
