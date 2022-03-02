using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;

namespace AppForSkills.Application.Users.Queries.GetUserRatings
{
    public class RatingDto : IMapFrom<Rating>
    {
        public int Value { get; set; }
        public int SkillId { get; set; }
        public string AuthorOfSkill { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rating, RatingDto>()
                .ForMember(s => s.AddressOfPhotoOrVideo, map => map.MapFrom(src => src.SkillPost.AddressOfPhotoOrVideo))
                .ForMember(s => s.SkillId, map => map.MapFrom(src => src.SkillPostId))
                .ForMember(s => s.Title, map => map.MapFrom(src => src.SkillPost.Title))
                .ForMember(s => s.Date, map => map.MapFrom(src => src.Created))
                .ForMember(s => s.AuthorOfSkill, map => map.MapFrom(src => src.SkillPost.CreatedBy));
        }
    }
}
