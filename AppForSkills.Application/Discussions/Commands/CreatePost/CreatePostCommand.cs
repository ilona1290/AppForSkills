using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppForSkills.Application.Discussions.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<int>, IMapFrom<PostInDiscussion>
    {
        public string PostText { get; set; }
        public int DiscussionId { get; set; }
        public int? ParentPostId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostCommand, PostInDiscussion>()
                .ForMember(s => s.PostText, map => map.MapFrom(src => src.PostText))
                .ForMember(s => s.DiscussionId, map => map.MapFrom(src => src.DiscussionId))
                .ForMember(s => s.ParentPostId, map => map.MapFrom(src => src.ParentPostId))
                .ForAllOtherMembers(d => d.Ignore());
        }
    }
}
