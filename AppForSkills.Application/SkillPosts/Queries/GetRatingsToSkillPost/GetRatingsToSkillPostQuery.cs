using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Queries.GetRatingsToSkillPost
{
    public class GetRatingsToSkillPostQuery : IRequest<RatingsPostVm>
    {
        public int SkillId { get; set; }
    }
}
