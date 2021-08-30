using AppForSkills.Application.Common.Mappings;
using AppForSkills.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .ForAllOtherMembers(d => d.Ignore());
        }
    }
}
