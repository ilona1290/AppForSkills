using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;

namespace AppForSkills.Application.SkillPosts.Queries.GetRatingsToSkillPost
{
    public class RatingPostDto : IMapFrom<Rating>
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rating, RatingPostDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.User.Username))
                .ForMember(s => s.Date, map => map.MapFrom(src => src.Created))
                .IncludeMembers(u => u.User);

            profile.CreateMap<User, RatingPostDto>()
                .ForMember(s => s.Avatar, map => map.MapFrom(src => src.Avatar));
        }
    }
}
