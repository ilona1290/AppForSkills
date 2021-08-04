using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Queries.GetDiscussion
{
    public class GetDiscussionQuery : IRequest<DiscussionVm>
    {
        public int DiscussionId { get; set; }
    }
}
