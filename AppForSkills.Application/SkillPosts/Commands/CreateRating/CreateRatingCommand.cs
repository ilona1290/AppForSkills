using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.CreateRating
{
    public class CreateRatingCommand : IRequest<int>, IMapFrom<Rating>
    {
        public int Value { get; set; }
        public int SkillPostId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRatingCommand, Rating>()
                .ForMember(s => s.Value, map => map.MapFrom(src => src.Value))
                .ForMember(s => s.SkillPostId, map => map.MapFrom(src => src.SkillPostId))
                .ForAllOtherMembers(d => d.Ignore());
        }
    }
}
