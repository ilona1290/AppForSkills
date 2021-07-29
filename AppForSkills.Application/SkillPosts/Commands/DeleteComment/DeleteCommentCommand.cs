using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public int CommentId { get; set; }
    }
}
