﻿using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserAchievements
{
    public class AchievementDto : IMapFrom<Achievement>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Achievement, AchievementDto>();
        }
    }
}