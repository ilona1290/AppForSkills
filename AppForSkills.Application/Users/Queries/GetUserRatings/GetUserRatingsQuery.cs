using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserRatings
{
    public class GetUserRatingsQuery : IRequest<RatingsVm>
    {
        public string Username { get; set; }
    }
}
