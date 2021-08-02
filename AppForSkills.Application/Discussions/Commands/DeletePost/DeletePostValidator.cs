using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.DeletePost
{
    public class DeletePostValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostValidator()
        {
            RuleFor(p => p.PostId).GreaterThan(0);
        }
    }
}
