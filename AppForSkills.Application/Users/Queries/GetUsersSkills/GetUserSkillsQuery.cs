using AppForSkills.Application.SkillPosts.Queries.GetSkillPosts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUsersSkills
{
    public class GetUserSkillsQuery : IRequest<SkillPostsVm>
    {
        public string Username { get; set; }
    }
}
