using AppForSkills.Application.Common.Mappings;
using AppForSkills.Application.Likes.Queries.GetLikes;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class CommentDto : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public int? MainParentCommentId { get; set; }
        public int? ParentCommentId { get; set; }
        public int StatusId { get; set; }
        public ICollection<LikeDto> Likes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.Date, map => map.MapFrom(src => src.Created))
                .IncludeMembers(u => u.User);

            profile.CreateMap<User, CommentDto>()
                .ForMember(s => s.Avatar, map => map.MapFrom(src => src.Avatar))
                .ForAllOtherMembers(f => f.Ignore());
        }
    }
}
