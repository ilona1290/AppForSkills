using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserRatings
{
    public class RatingDto : IMapFrom<Rating>
    {
        public int Value { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rating, RatingDto>()
                .ForMember(s => s.AddressOfPhotoOrVideo, map => map.MapFrom(src => src.SkillPost.AddressOfPhotoOrVideo))
                .ForMember(s => s.Title, map => map.MapFrom(src => src.SkillPost.Title))
                .ForMember(s => s.Date, map => map.MapFrom(src => src.Created));
        }
    }
}
