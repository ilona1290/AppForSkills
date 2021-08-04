using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int PostId { get; set; }
    }
}
