using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
