using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.Discussions.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<int>, IMapFrom<PostInDiscussion>
    {
        public string PostText { get; set; }
        public int DiscussionId { get; set; }
        public int? ParentPostId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostCommand, PostInDiscussion>();
        }
    }
}
