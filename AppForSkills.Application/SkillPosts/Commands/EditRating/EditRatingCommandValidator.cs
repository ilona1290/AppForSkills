using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.EditRating
{
    public class EditRatingCommandValidator : AbstractValidator<EditRatingCommand>
    {
        public EditRatingCommandValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0);
            RuleFor(r => r.Value).GreaterThan(0).LessThanOrEqualTo(5);
        }
    }
}
