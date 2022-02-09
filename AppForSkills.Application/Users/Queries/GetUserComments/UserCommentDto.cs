using AppForSkills.Application.Common.Mappings;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace AppForSkills.Application.Users.Queries.GetUserComments
{
    public class UserCommentDto : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int? ParentCommentId { get; set; }
        public string ParentCommentText { get; set; }
        public ICollection<LikeCommentDto> Likes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, UserCommentDto>()
                .ForMember(s => s.ParentCommentText, map => map.Ignore());
        }
    }
}
