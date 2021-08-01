using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.EditDiscussion
{
    public class EditDiscussionCommand : IRequest
    {
        public int DiscussionId { get; set; }
        public string FirstPost { get; set; }
    }
}
