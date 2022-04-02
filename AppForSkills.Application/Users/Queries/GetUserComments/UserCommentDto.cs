using AppForSkills.Application.Common.Mappings;
using AppForSkills.Application.Likes.Queries.GetLikes;
using AppForSkills.Application.SkillPosts.Queries.GetSkillPostDetail;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AppForSkills.Application.Users.Queries.GetUserComments
{
    public class UserCommentDto : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string AddressOfPhotoOrVideo { get; set; }
        public DateTime Date { get; set; }
        public string CommentText { get; set; }
        public int? MainParentCommentId { get; set; }
        public int? ParentCommentId { get; set; }
        public CommentDto ParentComment { get; set; }
        public ICollection<LikeDto> Likes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, UserCommentDto>()
                .ForMember(s => s.SkillId, map => map.MapFrom(src => src.SkillPostId))
                .ForMember(s => s.AddressOfPhotoOrVideo, map => map.MapFrom(src => src.SkillPost.AddressOfPhotoOrVideo))
                .ForMember(s => s.Date, map => map.MapFrom(src => src.Created))
                .ForMember(s => s.ParentComment, map => map.Ignore());
        }
    }
}
