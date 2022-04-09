using AppForSkills.Application.Common.Mappings;
using AppForSkills.Application.Likes.Queries.GetLikes;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AppForSkills.Application.Discussions.Queries.GetDiscussion
{
    public class PostInDiscussionDto : IMapFrom<PostInDiscussion>
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string PostText { get; set; }
        public int? MainParentPostId { get; set; }
        public int? ParentPostId { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
        public int StatusId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PostInDiscussion, PostInDiscussionDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.Date, map => map.MapFrom(src => src.Created))
                .IncludeMembers(u => u.User);

            profile.CreateMap<User, PostInDiscussionDto>()
                .ForMember(s => s.Avatar, map => map.MapFrom(src => src.Avatar));
        }
    }
}
