using FluentValidation;

namespace AppForSkills.Application.SkillPosts.Commands.DeleteSkillPost
{
    public class DeleteSkillPostValidator : AbstractValidator<DeleteSkillPostCommand>
    {
        public DeleteSkillPostValidator()
        {
            RuleFor(s => s.SkillPostId).GreaterThan(0);
        }
    }
}
