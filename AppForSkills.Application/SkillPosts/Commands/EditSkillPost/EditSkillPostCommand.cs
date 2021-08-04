using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.EditSkillPost
{
    public class EditSkillPostCommand : IRequest
    {
        public int Id { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
