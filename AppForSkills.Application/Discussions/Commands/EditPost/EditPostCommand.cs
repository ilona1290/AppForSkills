using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.EditPost
{
    public class EditPostCommand : IRequest
    {
        public int Id { get; set; }
        public string PostText { get; set; }
    }
}
