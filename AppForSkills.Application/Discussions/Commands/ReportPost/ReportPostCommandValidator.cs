using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.ReportPost
{
    public class ReportPostCommandValidator : AbstractValidator<ReportPostCommand>
    {
        public ReportPostCommandValidator()
        {
            RuleFor(e => e.PostId).GreaterThan(0);
        }
    }
}
