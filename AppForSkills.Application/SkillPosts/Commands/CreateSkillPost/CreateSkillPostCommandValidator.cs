using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.CreateSkillPost
{
    public class CreateSkillPostCommandValidator : AbstractValidator<CreateSkillPostCommand>
    {
        public CreateSkillPostCommandValidator()
        {
            RuleFor(s => s.NameOfPhotoOrVideo).NotEmpty();
            RuleFor(s => s.Title).NotEmpty().MaximumLength(100);
            RuleFor(s => s.Description).NotEmpty().MaximumLength(300);
        }
    }
}
