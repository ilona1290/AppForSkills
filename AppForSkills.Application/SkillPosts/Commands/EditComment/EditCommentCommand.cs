using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Application.SkillPosts.Commands.EditComment
{
    public class EditCommentCommand : IRequest
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
    }
}
