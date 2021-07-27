using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserInformation
{
    public class GetUserInformationQuery : IRequest<UserInformationVm>
    {
        public string Username { get; set; }
    }
}
