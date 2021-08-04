using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Queries.GetDiscussion
{
    public class DiscussionVm : IMapFrom<Discussion>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime PublishingDate { get; set; }
        public string FirstPost { get; set; }
        public List<PostInDiscussionDto> Posts  { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Discussion, DiscussionVm>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.PublishingDate, map => map.MapFrom(src => src.Created))
                .ForMember(s => s.Posts, map => map.MapFrom(src => src.PostsInDiscussion));
        }
    }


}
