using MediatR;

namespace AppForSkills.Application.SkillPosts.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public int CommentId { get; set; }
    }
}
