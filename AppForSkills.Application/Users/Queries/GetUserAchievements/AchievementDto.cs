using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;

namespace AppForSkills.Application.Users.Queries.GetUserAchievements
{
    public class AchievementDto : IMapFrom<Achievement>
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Achievement, AchievementDto>();
        }
    }
}
