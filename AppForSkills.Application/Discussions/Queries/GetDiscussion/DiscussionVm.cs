using AppForSkills.Application.Common.Mappings;
using AppForSkills.Application.Likes.Queries.GetLikes;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppForSkills.Application.Discussions.Queries.GetDiscussion
{
    public class DiscussionVm : IMapFrom<Discussion>
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public DateTime PublishingDate { get; set; }
        public string FirstPost { get; set; }
        public ICollection<PostInDiscussionDto> Posts { get; set; }
        public ICollection<LikeDto> Likes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Discussion, DiscussionVm>()
                .ForMember(s => s.Avatar, map => map.MapFrom(src => src.UsersInDiscussion.First().Avatar))
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.PublishingDate, map => map.MapFrom(src => src.Created))
                .ForMember(s => s.Posts, map => map.MapFrom(src => src.PostsInDiscussion));
        }
    }


}
