using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AppForSkills.Application.SkillPosts.Commands.CreateSkillPost
{
    public class CreateSkillPostCommand : IRequest<int>, IMapFrom<SkillPost>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Skill { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSkillPostCommand, SkillPost>()
                .ForMember(s => s.Title, map => map.MapFrom(src => src.Title))
                .ForMember(s => s.Description, map => map.MapFrom(src => src.Description))
                .ForAllOtherMembers(d => d.Ignore());
        }
    }
}
