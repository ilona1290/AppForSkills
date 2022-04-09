using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Commands.UpdateAvatar
{
    public class UpdateAvatarCommand : IRequest
    {
        public string Username { get; set; }
        public string Avatar { get; set; }
    }
}
