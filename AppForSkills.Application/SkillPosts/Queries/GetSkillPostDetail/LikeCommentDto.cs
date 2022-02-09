using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class LikeCommentDto : IMapFrom<Like>
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Like, LikeCommentDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.User));
        }
    }
}
