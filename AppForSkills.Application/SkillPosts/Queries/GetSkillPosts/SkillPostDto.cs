using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System.Linq;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPosts
{
    public class SkillPostDto : IMapFrom<SkillPost>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public int Comment { get; set; }
        public int Rating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SkillPost, SkillPostDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.Comment, map => map.MapFrom(src => src.Comments.Where(s => s.StatusId == 1).Count()))
                .ForMember(s => s.Rating, map => map.MapFrom(src => src.Ratings.Where(s => s.StatusId == 1).Count()));
        }
    }
}
