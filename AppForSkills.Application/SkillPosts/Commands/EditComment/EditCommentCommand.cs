using MediatR;

namespace AppForSkills.Application.SkillPosts.Commands.EditComment
{
    public class EditCommentCommand : IRequest
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
    }
}
