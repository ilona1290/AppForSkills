using AppForSkills.Application.Common.Mappings;
using AppForSkills.Application.Discussions.Queries.GetDiscussion;
using AppForSkills.Application.Likes.Queries.GetLikes;
using AppForSkills.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Users.Queries.GetUserDiscussionPosts
{
    public class UserDiscussionPostDto : IMapFrom<PostInDiscussion>
    {
        public int Id { get; set; }
        public int DiscussionId { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public string PostText { get; set; }
        public int? MainParentPostId { get; set; }
        public int? ParentPostId { get; set; }
        public PostInDiscussionDto ParentPost { get; set; }
        public ICollection<LikeDto> Likes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PostInDiscussion, UserDiscussionPostDto>()
                .ForMember(s => s.Topic, map => map.MapFrom(src => src.Discussion.FirstPost))
                .ForMember(s => s.Date, map => map.MapFrom(src => src.Created))
                .ForMember(s => s.ParentPost, map => map.Ignore());
        }
    }
}
