using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.DeleteDiscussion
{
    public class DeleteDiscussionValidator : AbstractValidator<DeleteDiscussionCommand>
    {
        public DeleteDiscussionValidator()
        {
            RuleFor(d => d.Id).GreaterThan(0);
        }
    }
}
