using MediatR;

namespace AppForSkills.Application.Discussions.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int PostId { get; set; }
    }
}
