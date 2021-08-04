using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.DeleteRating
{
    public class DeleteRatingCommand : IRequest
    {
        public int RatingId { get; set; }
    }
}
