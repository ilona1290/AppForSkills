using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class CommentDto : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public int? ParentCommentId { get; set; }
        public ICollection<LikeCommentDto> Likes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.Date, map => map.MapFrom(src => src.Created));
        }
    }
}
