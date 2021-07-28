using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserAchievements
{
    public class GetUserAchievementsQuery : IRequest<AchievementsVm>
    {
        public string Username { get; set; }
    }
}
