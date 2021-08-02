using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Commands.DeleteSkillPost
{
    public class DeleteSkillPostCommand : IRequest
    {
        public int SkillPostId { get; set; }
    }
}
