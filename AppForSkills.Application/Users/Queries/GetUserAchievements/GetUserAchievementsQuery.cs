﻿using AppForSkills.Application.Achievements.Queries.GetAchievements;
using MediatR;

namespace AppForSkills.Application.Users.Queries.GetUserAchievements
{
    public class GetUserAchievementsQuery : IRequest<AchievementsVm>
    {
        public string Username { get; set; }
    }
}
