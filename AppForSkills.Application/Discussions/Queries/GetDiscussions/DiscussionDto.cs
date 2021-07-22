using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.GetDiscussions
{
    public class DiscussionDto : IMapFrom<Discussion>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstPost { get; set; }
        public int Posts { get; set; }
        public int Likes { get; set; }
        public int Users { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Discussion, DiscussionDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.Posts, map => map.MapFrom(src => src.PostsInDiscussion.Count))
                .ForMember(s => s.Likes, map => map.MapFrom(src => src.Likes.Count))
                .ForMember(s => s.Users, map => map.MapFrom(src => src.UsersInDiscussion.Count));
        }
    }
}
