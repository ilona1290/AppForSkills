using FluentValidation;

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
