using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.EditSkillPost
{
    public class EditSkillPostCommandValidator : AbstractValidator<EditSkillPostCommand>
    {
        public EditSkillPostCommandValidator()
        {
            RuleFor(s => s.Id).GreaterThan(0);
            RuleFor(s => s.AddressOfPhotoOrVideo).NotEmpty();
            RuleFor(s => s.Title).NotEmpty().MaximumLength(100);
            RuleFor(s => s.Description).NotEmpty().MaximumLength(300);
        }
    }
}
