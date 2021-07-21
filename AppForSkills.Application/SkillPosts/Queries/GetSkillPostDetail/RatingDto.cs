using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class RatingDto : IMapFrom<Rating>
    {
        public int Value { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rating, RatingDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.Date, map => map.MapFrom(src => src.Created));
        }
    }
}
