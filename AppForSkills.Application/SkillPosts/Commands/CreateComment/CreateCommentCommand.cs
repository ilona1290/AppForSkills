using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppForSkills.Application.SkillPosts.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>, IMapFrom<Comment>
    {
        public string CommentText { get; set; }
        public int SkillPostId { get; set; }
        public int? ParentCommentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommentCommand, Comment>()
                .ForMember(s => s.CommentText, map => map.MapFrom(src => src.CommentText))
                .ForMember(s => s.SkillPostId, map => map.MapFrom(src => src.SkillPostId))
                .ForMember(s => s.ParentCommentId, map => map.MapFrom(src => src.ParentCommentId))
                .ForAllOtherMembers(d => d.Ignore());
        }
    }
}
