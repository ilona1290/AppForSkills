using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class LikeDto : IMapFrom<Like>
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Like, LikeDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.User));
        }
    }
}
