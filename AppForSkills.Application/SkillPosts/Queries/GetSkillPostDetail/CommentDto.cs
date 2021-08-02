using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail
{
    public class CommentDto : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public int? ParentCommentId { get; set; }
        public ICollection<CommentDto> AnswersToComment { get; set; }
        public ICollection<LikeDto> Likes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentDto>()
                .ForMember(s => s.Username, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(s => s.AnswersToComment, map => map
                .MapFrom(src => src.AnswersToComment.Where(a => a.ParentCommentId == src.Id)))
                .ForMember(s => s.Likes, map => map.MapFrom(src => src.Likes.Where(s => s.CommentId != null)));
        }
    }
}
