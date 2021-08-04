using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserComments
{
    public class GetUserCommentsQuery : IRequest<CommentsVm>
    {
        public string Username { get; set; }
    }
}
