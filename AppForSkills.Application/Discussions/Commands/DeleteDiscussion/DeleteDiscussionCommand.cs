using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.DeleteDiscussion
{
    public class DeleteDiscussionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
